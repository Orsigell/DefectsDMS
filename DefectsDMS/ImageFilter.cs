using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DefectsDMS
{
    public class ImageFilter
    {
        private Image image;

        public Image Image { get => image; set => image = value; }
        //Структура гистограмм
        public struct HistogramsRGBL
        {
            public Image RedHistogram;
            public Image GreenHistogram;
            public Image BlueHistogram;
            public Image LumHistogram;
        }
        private double Lum(int r, int g, int b)
        {
            return 0.3 * r + 0.59 * g + 0.11 * b;
        }
        //Гистограмма
        public HistogramsRGBL BarGraph(int sizeX, int sizeY)
        {
            Bitmap bitmap = (Bitmap)image;
            int[] redArr = new int[256];
            int[] greenArr = new int[256];
            int[] blueArr = new int[256];
            int[] sumColorArr = new int[256];
            for (int i = 0; i < bitmap.Height; i++)
            {
                for (int j = 0; j < bitmap.Width; j++)
                {
                    redArr[bitmap.GetPixel(j, i).R]++;
                    greenArr[bitmap.GetPixel(j, i).G]++;
                    blueArr[bitmap.GetPixel(j, i).B]++;
                    sumColorArr[(int)Lum(bitmap.GetPixel(j, i).R, bitmap.GetPixel(j, i).G, bitmap.GetPixel(j, i).B)]++;
                }
            }
            HistogramsRGBL histogramsRGBL = new HistogramsRGBL()
            {
                RedHistogram = GetBitmapHistogramFromColorArray(redArr, sizeX, sizeY, Color.Red),
                GreenHistogram = GetBitmapHistogramFromColorArray(greenArr, sizeX, sizeY, Color.Green),
                BlueHistogram = GetBitmapHistogramFromColorArray(blueArr, sizeX, sizeY, Color.Blue),
                LumHistogram = GetBitmapHistogramFromColorArray(sumColorArr, sizeX, sizeY, Color.Black)
            };
            return histogramsRGBL;
        }
        private static Bitmap GetBitmapHistogramFromColorArray(int[] colorArr, int sizeX, int sizeY, Color color)
        {
            Bitmap resultBitmap = new Bitmap(sizeX, sizeY);
            using (Graphics graphics = Graphics.FromImage(resultBitmap))
            {
                for (int i = 0; i < colorArr.Length; i++)
                {
                    graphics.DrawLine(new Pen(color, sizeX / colorArr.Length + 1), i * (sizeX / colorArr.Length + 1), (((float)-colorArr[i]) / colorArr.Max() * sizeY) + sizeY, i * (sizeX / colorArr.Length + 1), sizeY);
                }
            }
            return resultBitmap;
        }
        //Фильтрация
        public Image Filtration()
        {
            return null;
        }
        //Выделение дефета
        public Image HighlightingDefect()
        {
            MemoryStream memoryStream = new MemoryStream();
            image.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Png);
            byte[] ImageToByteArr = memoryStream.ToArray();

            using (var client = new HttpClient())
            using (var formData = new MultipartFormDataContent())
            {
                formData.Headers.Add("X-Api-Key", "gPPxYaiJWoJdesDuTknKjVEV");
                formData.Add(new ByteArrayContent(ImageToByteArr), "image_file", "file.jpg");
                formData.Add(new StringContent("auto"), "size");
                var response = client.PostAsync("https://api.remove.bg/v1.0/removebg", formData).Result;
                if (response.IsSuccessStatusCode)
                {
                    MemoryStream memoryStream2 = new MemoryStream();
                    response.Content.CopyToAsync(memoryStream2).ContinueWith((copyTask) => { });
                    Image resultImage = Image.FromStream(memoryStream2);
                    memoryStream2.Close();
                    return resultImage;
                }
                else
                {
                    throw new Exception("Не удалось провести выделение дфекта");
                }
            }
        }
        private class Area
        {
            public Area(int x, int y, int accuracy, Bitmap bitmap)
            {
                AreaId = MaxId;
                Colors.Add(bitmap.GetPixel(x, y));
                FindeArea(accuracy, bitmap, x, y);
                while (lossCalls.Count != 0)
                {
                    callCount = 0;
                    LossCall lossCall = lossCalls.Pop();
                    FindeArea(lossCall.Accuracy, lossCall.Bitmap, lossCall.CurentX, lossCall.CurentY);
                }
                MaxId++;
            }
            public Area(int id)
            {
                AreaId = id;
            }
            private bool RoughlyEqual(Color color1, Color color2, int accuracy)
            {
                if (!((color1.R - accuracy <= color2.R) && (color1.R + accuracy >= color2.R)))
                {
                    return false;
                }
                if (!((color1.G - accuracy <= color2.G) && (color1.G + accuracy >= color2.G)))
                {
                    return false;
                }
                if (!((color1.B - accuracy <= color2.B) && (color1.B + accuracy >= color2.B)))
                {
                    return false;
                }
                return true;
            }
            private bool LeftAreasCheck(int accuracy, Bitmap bitmap, int x, int y)
            {
                if (x > 0)
                {
                    return (Areas[x - 1, y] == null) && RoughlyEqual(Colors[AreaId], bitmap.GetPixel(x - 1, y), accuracy);
                }
                else
                {
                    return false;
                }
            }
            private bool UpAreasCheck(int accuracy, Bitmap bitmap, int x, int y)
            {
                if (y > 1)
                {
                    return (Areas[x, y - 1] == null) && RoughlyEqual(Colors[AreaId], bitmap.GetPixel(x, y - 1), accuracy);
                }
                else
                {
                    return false;
                }
            }
            private bool RightAreasCheck(int accuracy, Bitmap bitmap, int x, int y)
            {
                if (x + 1 < bitmap.Width)
                {
                    return (Areas[x + 1, y] == null) && RoughlyEqual(Colors[AreaId], bitmap.GetPixel(x + 1, y), accuracy);
                }
                else
                {
                    return false;
                }
            }
            private bool DownAreasCheck(int accuracy, Bitmap bitmap, int x, int y)
            {
                if (y + 1 < bitmap.Height)
                {
                    return (Areas[x, y + 1] == null) && RoughlyEqual(Colors[AreaId], bitmap.GetPixel(x, y + 1), accuracy);
                }
                else
                {
                    return false;
                }
            }
            private void FindeArea(int accuracy, Bitmap bitmap, int curentX, int curentY)
            {
                callCount++;
                if (callCount < MaxCallCount)
                {
                    if (LeftAreasCheck(accuracy, bitmap, curentX, curentY))
                    {
                        Areas[curentX - 1, curentY] = new Area(AreaId);
                        FindeArea(accuracy, bitmap, curentX - 1, curentY);
                    }
                    if (UpAreasCheck(accuracy, bitmap, curentX, curentY))
                    {
                        Areas[curentX, curentY - 1] = new Area(AreaId);
                        FindeArea(accuracy, bitmap, curentX, curentY - 1);
                    }
                    if (RightAreasCheck(accuracy, bitmap, curentX, curentY))
                    {
                        Areas[curentX + 1, curentY] = new Area(AreaId);
                        FindeArea(accuracy, bitmap, curentX + 1, curentY);
                    }
                    if (DownAreasCheck(accuracy, bitmap, curentX, curentY))
                    {
                        Areas[curentX, curentY + 1] = new Area(AreaId);
                        FindeArea(accuracy, bitmap, curentX, curentY + 1);
                    }
                }
                else
                {
                    lossCalls.Push(new LossCall(accuracy, bitmap, curentX, curentY));
                }
            }
            private struct LossCall
            {
                public LossCall(int accuracy, Bitmap bitmap, int curentX, int curentY)
                {
                    Accuracy = accuracy;
                    Bitmap = bitmap;
                    CurentX = curentX;
                    CurentY = curentY;
                }
                public int Accuracy;
                public Bitmap Bitmap;
                public int CurentX;
                public int CurentY;
            }
            public static void RefreshClass()
            {
                MaxId = 0;
                Colors = new List<Color>();
                Areas = null;
            }
            private Stack<LossCall> lossCalls = new Stack<LossCall>();
            private int callCount = 0;
            private const int MaxCallCount = 5000;
            public int AreaId = 0;
            public static List<Color> Colors = new List<Color>();
            public static int MaxId = 0;
            public static Area[,] Areas;
        }
        //Cегментация
        public Bitmap Segmentation( int accuracy)
        {
            Area.RefreshClass();
            Bitmap resultBitmap = (Bitmap)Image;
            Area.Areas = new Area[resultBitmap.Width, resultBitmap.Height];
            for (int x = 0; x < resultBitmap.Width; x++)
            {
                for (int y = 0; y < resultBitmap.Height; y++)
                {
                    if (Area.Areas[x, y] == null)
                    {
                        Area.Areas[x, y] = new Area(x, y, accuracy, resultBitmap);
                    }
                }
            }
            using (Graphics graphics = Graphics.FromImage(resultBitmap))
            {

                List<Color> randomColors = new List<Color>();
                Random random = new Random();
                foreach (var item in Area.Colors)
                {
                    randomColors.Add(Color.FromArgb(random.Next(256), random.Next(256), random.Next(256)));
                }
                for (int x = 0; x < resultBitmap.Width; x++)
                {
                    for (int y = 0; y < resultBitmap.Height; y++)
                    {
                        graphics.FillRectangle(new SolidBrush(randomColors[Area.Areas[x, y].AreaId]), x, y, 1, 1);
                    }
                }
            }
            return resultBitmap;
        }
        //Сглаживание
        public Bitmap ImageSmoothing(int accuracy)
        {
            Area.RefreshClass();
            Bitmap resultBitmap = (Bitmap)Image;
            Area.Areas = new Area[resultBitmap.Width, resultBitmap.Height];
            for (int x = 0; x < resultBitmap.Width; x++)
            {
                for (int y = 0; y < resultBitmap.Height; y++)
                {
                    if (Area.Areas[x, y] == null)
                    {
                        Area.Areas[x, y] = new Area(x, y, accuracy, resultBitmap);
                    }
                }
            }
            using (Graphics graphics = Graphics.FromImage(resultBitmap))
            {
                for (int x = 0; x < resultBitmap.Width; x++)
                {
                    for (int y = 0; y < resultBitmap.Height; y++)
                    {
                        graphics.FillRectangle(new SolidBrush(Area.Colors[Area.Areas[x, y].AreaId]), x, y, 1, 1);
                    }
                }
            }
            return resultBitmap;
        }
        private Color NegativeColor(Color color)
        {
            return Color.FromArgb(255 - color.R, 255 - color.G, 255 - color.B);
        }
        //Негатив
        public Image Negative()
        {
            Bitmap resultImage = (Bitmap)Image;
            for (int x = 0; x < resultImage.Width; x++)
            {
                for (int y = 0; y < resultImage.Height; y++)
                {
                    resultImage.SetPixel(x, y, NegativeColor(resultImage.GetPixel(x, y)));
                }
            }
            return resultImage;
        }
    }
}
