using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PW.ApplicationContracts.Interfaces;
using PW.ApplicationContracts.ViewModels;

namespace PW.UI.Areas.AdminPanel.Pages.SiteManagement.Testimonial
{
    public class IndexModel : PageModel
    {

        private readonly ITestimonialApplication _itestimonial_application;

        public List<TestimonialViewModel> TestimonialVM { get; set; }
        public CourseViewModel SearchModel { get; set; }

        public IndexModel(ITestimonialApplication itestimonial_application)
        {
            _itestimonial_application = itestimonial_application;
        }

        public void OnGet(TestimonialViewModel searchmodel)
        {
            TestimonialVM = _itestimonial_application.Search(searchmodel);
        }
        public IActionResult OnGetView(long id)
        {
            var selecteditem = _itestimonial_application.GetDetails(id);
            return Partial("./View", selecteditem);
        }
        public IActionResult OnGetRemove(TestimonialViewModel testimonialvm)
        {
            _itestimonial_application.Remove(testimonialvm.Id);
            return RedirectToPage("Index");
        }

        public IActionResult OnGetToVisible(TestimonialViewModel testimonialvm)
        {
            _itestimonial_application.ToVisible(testimonialvm.Id);
            return RedirectToPage("Index");
        }
        public IActionResult OnGetToInvisible(TestimonialViewModel testimonialvm)
        {
            _itestimonial_application.ToInvisible(testimonialvm.Id);
            return RedirectToPage("Index");
        }

    }
}
