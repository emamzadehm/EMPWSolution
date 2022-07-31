
using Microsoft.AspNetCore.Http;

namespace PW.ApplicationContracts.ViewModels
{
    public class ProfessorViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        public string Level { get; set; }
        public string ImgAddress { get; set; }
        public IFormFile IMGContent { get; set; }
        public string Tel { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string LinkedInURL { get; set; }
        public string MapAddress { get; set; }

    }
}
