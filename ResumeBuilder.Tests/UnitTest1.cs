using ResumeBuilder.Models;
using ResumeBuilder.Controllers;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Diagnostics.Metrics;
using System.Numerics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.HttpResults;
namespace ResumeBuilder.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Generate_PDF()
        {
            //ARRANGE
            CvModel model = new CvModel();
            HomeController controller = new HomeController();
            model.Name = "John";
            model.Surname = "Doe";
            model.DateOfBirth = "01-01-2000";
            model.Country = "Poland";
            model.City = "Warsaw";
            model.Phone = "123-456-789";
            model.Email = "john.doe@example.com";
            model.Languages = "English, C1";
            model.Training = "None";
            model.Profile = "Developer";
            model.Interests = "Coding";
            model.Links = "https://linkedin.com/in/johndoe";
            model.Consent = "Yes";
            
            //ACT
            IActionResult result = controller.GeneratePDF(model);

            //ASSERT
            Assert.IsNotType<BadRequest>(result);

            if (result is FileContentResult fileResult)
            {
                string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "UnitTestCV.pdf");
                File.WriteAllBytes(outputPath, fileResult.FileContents);

            }
        }
    }
}