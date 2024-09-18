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
            HomeController controller = new HomeController();
            CvModel model = new CvModel
            {
                Name = "John",
                Surname = "Doe",
                DateOfBirth = "01-01-2000",
                Country = "Poland",
                City = "Warsaw",
                Phone = "123-456-789",
                Email = "john.doe@example.com",
                ProfessionalExperience = new List<ProfessionalExperience>
                {
                    new ProfessionalExperience { Title = "Developer", Date = "2021-2023", Description = "Worked as developer" }
                },
                Education = new List<Education>
                {
                    new Education { Title = "BSc in Computer Science", Date = "2017-2021", Description = "Graduated with honors" }
                },
                Languages = "English, C1",
                Development = "C#, ASP.NET",
                Other = "Git",
                Interests = "Coding",
                Links = "https://linkedin.com/in/johndoe",
                Consent = "Yes"
            };

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