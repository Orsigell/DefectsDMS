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
        public HistogramsRGBL BarGraph(int sizeX, int sizeY)//Гистограмма
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
        public Image Filtration()//Фильтрация
        {
            return null;
        }
        public Image HighlightingBbackground()//Выделение фона
        {
            return null;
        }
        public Image HighlightingDefect()//Выделение дефета
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
                    throw new Exception();
                }
            }
        }
        public Image Segmentation()//Сегментация
        {
            return null;
        }
    }
}
