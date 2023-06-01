using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Mvc;

namespace _Traversal.Areas.Admin.Controllers
{
    public class PdfController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult StaticPdfReport()
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot","PdfReports","dosya1.pdf");
            
            using(var stream  = new FileStream(path,FileMode.Create))
            {
                Document document = new Document(PageSize.A4, 30, 30, 30, 30);
                PdfWriter.GetInstance(document, stream);

                document.Open();
                Paragraph paragraph = new Paragraph("Traversal Rezervasyon PDF Raporu");
                document.Add(paragraph);
                document.Close();

                return File("PdfReports/dosya1.pdf", "application/pdf", "DestinationReport.pdf");
            }
        }
        public IActionResult StaticPdfTableReport()
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "PdfReports", "dosya1.pdf");

            using (var stream = new FileStream(path, FileMode.Create))
            {
                Document document = new Document(PageSize.A4, 30, 30, 30, 30);
                PdfWriter.GetInstance(document, stream);

                document.Open();
                PdfPTable pdfTable = new PdfPTable(3);



                //Arial Font'unun Bilgisayarda Bulunduğu Yeri String Olarak Alıyoruz.
                string Arial_TFF = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "Arial.ttf");

                //iTextSharp için bir BaseFont örneği oluşturuyoruz.
                BaseFont bf = BaseFont.CreateFont(Arial_TFF, BaseFont.IDENTITY_H, true);

                //Yine dökümanda kullanabilmek için bu sefer ana font örneği oluşturuyoruz. Bu örneklemede font büyüklüğünü
                //ve diğer attributelerini de değiştirebilirsiniz.
                Font f = new Font(bf, 12, Font.NORMAL);

                //Döküman için başlık paragrafı oluşturuyoruz, paragrafın sonuna bir f yani Font overloadı ekleyerek
                //Türkçe karakter desteklemesini ve istediğimiz fontu kullanmasını sağlıyoruz.



                pdfTable.AddCell(new Phrase("Misafir Adı", f));
                pdfTable.AddCell(new Phrase("Misafir Soyadı", f));
                pdfTable.AddCell(new Phrase("Misafir TC", f));

                pdfTable.AddCell(new Phrase("Anıl",f));
                pdfTable.AddCell(new Phrase("ONAY", f));
                pdfTable.AddCell("21412345232");


                pdfTable.AddCell(new Phrase("Selim", f));
                pdfTable.AddCell(new Phrase("Sarı", f));
                pdfTable.AddCell("12345678901");

                pdfTable.AddCell(new Phrase("İnci", f));
                pdfTable.AddCell(new Phrase("Gök", f));
                pdfTable.AddCell("12343568901");

                document.Add(pdfTable);

                document.Close();

                return File("PdfReports/dosya1.pdf", "application/pdf", "TableReport.pdf");
            }
        }
    }
}
