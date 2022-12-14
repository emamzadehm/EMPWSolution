using Microsoft.AspNetCore.Mvc;
using PW.ApplicationContracts.Interfaces;

namespace PW.UI.ViewComponents
{
    public class MenuViewComponent : ViewComponent
    {
        private readonly IProfessorApplication _iprofessorapplication;

        public MenuViewComponent(IProfessorApplication iprofessorapplication)
        {
            _iprofessorapplication = iprofessorapplication;
        }

        public IViewComponentResult Invoke()
        {
            var selectedprofessor = _iprofessorapplication.GetDetails(1);
            return View("_Menu", selectedprofessor);
        }
    }
}
