using Microsoft.AspNetCore.Mvc;
using PdfSharp.Drawing;
using PdfSharp.Drawing.Layout;
using PdfSharp.Pdf;
using ResumeBuilder.Models;
using System.Diagnostics;
using System.IO;
using System.Runtime.Intrinsics.Arm;
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
                XFont font = new XFont("Arial", 14, XFontStyleEx.Regular);
                XSolidBrush color = XBrushes.Black;
                XStringFormat stringFormat = XStringFormats.Center;

                //Drawing content
                double y = 160;
                double lineHeight = 23.1;

                /*using (var ms = new MemoryStream())
                {
                    model.Photo.CopyTo(ms);
                    ms.Position = 0;
                    XImage photo = XImage.FromStream(ms);
                    
                    //Proportions
                    double x = photo.Width / photo.Height;
           
                    gfx.DrawImage(photo, new XRect(20, 20, 140*x, 140));
                }*/
                void DrawText(string text)
                {
                    gfx.DrawString(text, font, color, new XRect(20, y, page.Width - 40, lineHeight), XStringFormats.Center);
                    y += lineHeight;
                }
                gfx.DrawString(model.Name + " " + model.Surname, new XFont("Arial", 20, XFontStyleEx.Regular), color, new XRect(20, 20, page.Width - 40, lineHeight), XStringFormats.Center);
                DrawText("Date of Birth: " + model.DateOfBirth);
                DrawText("From: " + model.City + ", " + model.Country);
                DrawText("Phone number: " + model.Phone);
                DrawText("E-mail: " + model.Email);
                DrawText("Work Experience: " + model.ProfessionalExperience);
                DrawText("Education: " + model.Education);
                DrawText("Languages: " + model.Languages);
                DrawText("Training: " + model.Training);
                DrawText("Work Profile: " + model.Profile);
                DrawText("Interests: " + model.Interests);
                DrawText("Links: " + model.Links);
                DrawText("Consent: " + model.Consent);

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
