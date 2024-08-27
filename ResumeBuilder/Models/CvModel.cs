using System.ComponentModel.DataAnnotations;

namespace ResumeBuilder.Models
{
    public class CvModel
    {
        [Required]
        public string Name { get; set; }
        public string Surname { get; set; }
        public string DateOfBirth { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string ProfessionalExperience { get; set; }
        public string Education { get; set; }
        public string Languages { get; set; }
        public string Training { get; set; }
        public string Profile { get; set; }
        public string Skills { get; set; }
        public string Interests { get; set; }
        public string Links { get; set; }
        public string Consent { get; set; }
    }
}
