using Microsoft.AspNetCore.Mvc;
using PdfSharp.Drawing;
using PdfSharp.Drawing.Layout;
using PdfSharp.Pdf;
using ResumeBuilder.Models;
using ResumeBuilder.Utilities;
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
                XFont font = new XFont("Arial", 14, XFontStyleEx.Regular);
                XGraphics gfx = XGraphics.FromPdfPage(page);
                XSolidBrush color = XBrushes.Black;
                XStringFormat stringFormat = XStringFormats.Center;

                //Drawing content
                double y = 141.3;
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
                void Enter()
                {
                    y += lineHeight;
                }
                void DrawText(string text, double size = 14, XFontStyleEx style = XFontStyleEx.Regular)
                {
                    XFont font = new XFont("Arial", size, style);
                    gfx.DrawString(text, font, color, new XRect(72, y, page.Width - 40, lineHeight), XStringFormats.CenterLeft);
                    Enter();
                };
                void DrawTextXY(string text, double rectx, double recty)
                {
                    XFont font = new XFont("Arial", 14, XFontStyleEx.Regular);
                    gfx.DrawString(text, font, color, new XRect(rectx, recty, page.Width - 40, lineHeight), XStringFormats.CenterLeft);
                }
                gfx.DrawString(model.Name + " " + model.Surname, new XFont("Arial", 23, XFontStyleEx.Bold), color, new XRect(20, 72, page.Width - 40, lineHeight), XStringFormats.Center);
                gfx.DrawString(model.City + ", " + model.Country + " | " + model.Phone + " | " + model.Email, font, color, new XRect(20, 95.1, page.Width - 40, lineHeight), XStringFormats.Center);
                gfx.DrawString(model.Links, font, color, new XRect(20, 118.2, page.Width - 40, lineHeight), XStringFormats.Center);
                Enter();
                gfx.DrawLine(new XPen(XColors.Black), 72, y, 523, y);
                Enter();
                DrawText("Skills ", 19, XFontStyleEx.Bold);
                DrawText("Development ", 14, XFontStyleEx.Bold);
                DrawTextXY(model.Development, 200, y-lineHeight);
                DrawText("Other ", 14, XFontStyleEx.Bold);
                DrawTextXY(model.Other, 200, y - lineHeight);
                DrawText("Languages ", 14, XFontStyleEx.Bold);
                DrawTextXY(model.Languages, 200, y - lineHeight);
                Enter();
                gfx.DrawLine(new XPen(XColors.Black), 72, y, 523, y);
                Enter();
                DrawText("Experience ", 19, XFontStyleEx.Bold);
                foreach (var experience in model.ProfessionalExperience)
                {
                    DrawText(experience.Title, 14, XFontStyleEx.Bold);
                    gfx.DrawString(experience.Date, new XFont("Arial", 14, XFontStyleEx.Bold), color, new XRect(0, y - lineHeight, 523, lineHeight), XStringFormats.CenterRight);

                    y += lineHeight/1.4;
                    y = PdfMultiLineUtility.DrawMultilineText(gfx, experience.Description, font, color, new XPoint(72, y), lineHeight);
                    Enter();
                }

                Enter();
                gfx.DrawLine(new XPen(XColors.Black), 72, y, 523, y);
                Enter();
                DrawText("Education ", 19, XFontStyleEx.Bold);
                foreach (var education in model.Education)
                {
                    DrawText(education.Title, 14, XFontStyleEx.Bold);
                    gfx.DrawString(education.Date, new XFont("Arial", 14, XFontStyleEx.Bold), color, new XRect(0, y - lineHeight, 523, lineHeight), XStringFormats.CenterRight);

                    y += lineHeight / 1.4;
                    y = PdfMultiLineUtility.DrawMultilineText(gfx, education.Description, font, color, new XPoint(72, y), lineHeight);
                    Enter();
                }
                var consentTextHeight = PdfWrapTextUtility.CalculateTextHeight(gfx, model.Consent, font, 523);
                PdfWrapTextUtility.DrawWrappedText(gfx, model.Consent, new XFont("Arial", 9, XFontStyleEx.Regular), XBrushes.DimGray, new XRect(72, y, 451, consentTextHeight), XStringFormats.TopLeft);

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
