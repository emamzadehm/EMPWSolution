using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PW.ApplicationContracts.Interfaces;
using PW.ApplicationContracts.ViewModels;

namespace PW.UI.Areas.AdminPanel.Pages.SiteManagement.Professor
{
    public class IndexModel : PageModel
    {

        private readonly IProfessorApplication _iprofessor_application;

        public List<ProfessorViewModel> ProfessorVM { get; set; }
        public ProfessorViewModel SearchModel { get; set; }

        public IndexModel(IProfessorApplication iprofessor_application)
        {
            _iprofessor_application = iprofessor_application;
        }

        public void OnGet(ProfessorViewModel searchmodel)
        {
            ProfessorVM = _iprofessor_application.Search(searchmodel);
        }
        public IActionResult OnGetEdit(long id)
        {
            var selecteditem = _iprofessor_application.GetDetails(id);
            return Partial("./Edit", selecteditem);
        }
        public JsonResult OnPostEdit(ProfessorViewModel coursevm)
        {
            var result = _iprofessor_application.Edit(coursevm);
            return new JsonResult(result);
        }

    }
}
