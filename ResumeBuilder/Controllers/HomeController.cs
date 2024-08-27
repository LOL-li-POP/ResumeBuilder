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
                XSolidBrush color = XBrushes.Black;
                XStringFormat stringFormat = XStringFormats.Center;
                XRect rect = new XRect(0, 0, page.Width, page.Height);
                
                //Drawing content
                gfx.DrawString(model.Name + " " + model.Surname, font, color, rect, stringFormat);
                gfx.DrawString(model.DateOfBirth, font, color, rect, stringFormat);
                gfx.DrawString("From: " + model.City + ", " + model.Country, font, color, rect, stringFormat);
                gfx.DrawString("Phone number: " + model.Phone, font, color, rect, stringFormat);
                gfx.DrawString("E-mail: " + model.Email, font, color, rect, stringFormat);
                gfx.DrawString("Work Experience: " + model.ProfessionalExperience, font, color, rect, stringFormat);
                gfx.DrawString("Education: " + model.Education, font, color, rect, stringFormat);
                gfx.DrawString("Languages: " + model.Languages, font, color, rect, stringFormat);
                gfx.DrawString("Training: " + model.Training, font, color, rect, stringFormat);
                gfx.DrawString("Work Profile: " + model.Profile, font, color, rect, stringFormat);
                gfx.DrawString("Interests: " + model.Interests, font, color, rect, stringFormat);
                gfx.DrawString("Links: " + model.Links, font, color, rect, stringFormat);
                gfx.DrawString("Consent: " + model.Consent, font, color, rect, stringFormat);

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
