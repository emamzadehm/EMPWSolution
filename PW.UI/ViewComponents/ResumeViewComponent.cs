using Microsoft.AspNetCore.Mvc;
using PW.ApplicationContracts.Interfaces;
using System.Linq;

namespace Emamzadeh.ViewComponents
{
    public class ResumeViewComponent : ViewComponent
    {
        private readonly IResumeApplication _iresumeapplication;

        public ResumeViewComponent(IResumeApplication iresumeapplication)
        {
            _iresumeapplication = iresumeapplication;
        }

        public IViewComponentResult Invoke()
        {
            var resumelist = _iresumeapplication.Search(null).OrderByDescending(x=>x.Priority);
            return View("_Resume", resumelist);
        }
    }
}
