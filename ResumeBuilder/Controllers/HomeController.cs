using Microsoft.AspNetCore.Mvc;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using ResumeBuilder.Models;
using System.Diagnostics;
using System.IO;
using static System.Net.Mime.MediaTypeNames;

namespace ResumeBuilder.Controllers
{
    public class HomeController : Controller
    {
        //handles Get requests
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        //handles Post requests
        [HttpPost]
        //generates pdf file
        public IActionResult GeneratePDF(CvModel model)
        {
            //Validation breaks code somehow
            if (ModelState.IsValid)
            {
                //if code isn't understandable visit https://www.pdfsharp.net/wiki/PDFsharpFirstSteps.ashx
                PdfDocument document = new PdfDocument();
                PdfPage page = document.AddPage();
                XGraphics gfx = XGraphics.FromPdfPage(page);
                XFont font = new XFont("Arial", 11, XFontStyleEx.Regular);
                gfx.DrawString("Hello, World!", font, XBrushes.Black,
                    new XRect(0, 0, page.Width, page.Height),
                    XStringFormat.Center);
                string filename = "CV.pdf";
                using (var stream = new MemoryStream())
                {
                    document.Save(stream, false);
                    stream.Position = 0;

                    return File(stream.ToArray(), "application/pdf", filename);
                }
            }
            return BadRequest(ModelState);
        }
    }
}
