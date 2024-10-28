using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TravelCore.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Pdf")]
    [Authorize(Roles = "admin")]

    public class PdfController : Controller
    {
        [Route("Index")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("StaticPdfReport")]

        public IActionResult StaticPdfReport() 
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/pdfreports/" + "dosya1.pdf");
            var stream=new FileStream(path, FileMode.Create);
            Document document = new Document(PageSize.A4);
            PdfWriter.GetInstance(document, stream);

            document.Open();
            Paragraph paragraf = new Paragraph("Traversal Rezervasyon pdf raporu");
            document.Add(paragraf);
            document.Close();
            return File("/pdfreports/dosya1.pdf", "apllication/pdf", "PdfReport1.pdf");


        }

        [Route("DynamicPdfReport")]

        public IActionResult DynamicPdfReport()
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/pdfreports/" + "dosya1.pdf");
            var stream = new FileStream(path, FileMode.Create);
            Document document = new Document(PageSize.A4);
            PdfWriter.GetInstance(document, stream);

            document.Open();

            PdfPTable pdfTable = new PdfPTable(3);

            pdfTable.AddCell("Misafir Adı");
            pdfTable.AddCell("Misafir Soyadı");
            pdfTable.AddCell("Telefon");
            
            pdfTable.AddCell("Mümtaz");
            pdfTable.AddCell("Kemal");
            pdfTable.AddCell("052131241"); pdfTable.AddCell("Misafir Adı");
            
            pdfTable.AddCell("Ahmet");
            pdfTable.AddCell("Cellek");
            pdfTable.AddCell("054213243");

            document.Add(pdfTable);
            document.Close();
            return File("/pdfreports/dosya1.pdf", "apllication/pdf", "PdfReportDynamic.pdf");


        }


    }
}
