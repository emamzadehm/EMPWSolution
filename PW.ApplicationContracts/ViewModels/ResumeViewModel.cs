using Microsoft.AspNetCore.Http;

namespace PW.ApplicationContracts.ViewModels
{
    public class ResumeViewModel
    {
        public long Id { get; set; }
        public string FromYear { get; set; }
        public string ToYear { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Priority { get; set; }
        public string Icon { get; set; }
        public IFormFile IconFile { get; set; }
        public bool Status { get; set; }



    }
}
