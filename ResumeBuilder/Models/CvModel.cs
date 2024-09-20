using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace ResumeBuilder.Models
{
    public class CvModel
    {
        //public IFormFile Photo { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public string DateOfBirth { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public List<ProfessionalExperience> ProfessionalExperience { get; set; } = new List<ProfessionalExperience>();
        public List<Education> Education { get; set; } = new List<Education>();
        public string Languages { get; set; } = string.Empty;
        public string Training { get; set; } = string.Empty;
        public string Profile { get; set; } = string.Empty;
        public string Development { get; set; } = string.Empty;
        public string Other { get; set; } = string.Empty;
        public string Interests { get; set; } = string.Empty;
        public string Links { get; set; } = string.Empty;
        public string Consent { get; set; } = string.Empty;
    }
}
