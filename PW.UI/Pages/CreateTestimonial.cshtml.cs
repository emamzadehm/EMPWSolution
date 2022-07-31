using Microsoft.AspNetCore.Mvc.RazorPages;
using PW.ApplicationContracts.Interfaces;
using PW.ApplicationContracts.ViewModels;

namespace PW.UI.Pages
{
    public class CreateTestimonialModel : PageModel
    {
        public TestimonialViewModel TestimonialVM { get; set; }
        private readonly ITestimonialApplication _itestimonialapplication;
        
        public string ErrorMessage { get; set; }
        public string SuccessMessage { get; set; }

        public CreateTestimonialModel(ITestimonialApplication itestimonialapplication)
        {
            _itestimonialapplication = itestimonialapplication;
        }

        public void OnGet()
        {

        }
        
        public void OnPost(TestimonialViewModel testimonialvm)
            {
            if (!ModelState.IsValid)
            {
                ErrorMessage = "اطلاعات ثبت نگردید. لطفاً مجدداً تلاش نمائید.";
            }
            else
            {
                _itestimonialapplication.Create(testimonialvm);
                SuccessMessage = "اطلاعات با موفقیت ثبت گردید. با تشکر.";
                ModelState.Clear();
            }
        }
    }

}