using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefectsDMS
{
    public static class PDFCreator
    {
        public struct FilterResult
        {
            public FilterResult(string name, System.Drawing.Image image)
            {
                Name = name;
                Image = image;
            }
            public string Name;
            public System.Drawing.Image Image;
        }
        public static void CreateDocument(string reportName, params FilterResult[] image)
        {
            Document pdf = new Document(PageSize.A3, 10, 10, 50, 20);
            PdfWriter.GetInstance(pdf, new FileStream($"{reportName}.pdf", FileMode.OpenOrCreate));
            pdf.Open();

            string ttf = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "ARIAL.TTF");
            BaseFont baseFont = BaseFont.CreateFont(ttf, BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
            Font font = new Font(baseFont, Font.DEFAULTSIZE, Font.NORMAL);


            PdfPTable table = new PdfPTable(2);
            table.SetWidths(new float[] { 100, 400 });
            table.AddCell(new PdfPCell(new Phrase("\n Название фильтра\n ", font)));
            table.AddCell(new PdfPCell(new Phrase("\n Результат работы фильтра\n ", font)));
            for (int i = 0; i < image.Length; i++)
            {
                PdfPCell cell = new PdfPCell(new Phrase(new Phrase(image[i].Name, font)));
                table.AddCell(cell);
                Image png = Image.GetInstance(image[i].Image, BaseColor.LIGHT_GRAY);
                png.ScalePercent(40f);
                cell = new PdfPCell(png);
                table.AddCell(cell);
            }
            pdf.Add(table);
            pdf.Close();
        }
    }
}
