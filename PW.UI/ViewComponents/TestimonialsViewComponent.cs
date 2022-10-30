using Microsoft.AspNetCore.Mvc;
using PW.ApplicationContracts.Interfaces;
using System.Linq;

namespace PW.UI.ViewComponents
{
    public class TestimonialsViewComponent : ViewComponent
    {
        private readonly ITestimonialApplication _itestimonialapplication;

        public TestimonialsViewComponent(ITestimonialApplication itestimonialapplication)
        {
            _itestimonialapplication = itestimonialapplication;
        }

        public IViewComponentResult Invoke()
        {
            var testimonialslist = _itestimonialapplication.Search(null).Where(x => x.IsVisible == true);
            return View("_Testimonials", testimonialslist);
        }
    }
}
