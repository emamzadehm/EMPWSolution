using Microsoft.AspNetCore.Mvc;
using PW.ApplicationContracts.Interfaces;

namespace PW.UI.ViewComponents
{
    public class MenuPagesViewComponent : ViewComponent
    {
        private readonly IProfessorApplication _iprofessorapplication;

        public MenuPagesViewComponent(IProfessorApplication iprofessorapplication)
        {
            _iprofessorapplication = iprofessorapplication;
        }

        public IViewComponentResult Invoke()
        {
            var selectedprofessor = _iprofessorapplication.GetDetails(1);
            return View("_MenuPages", selectedprofessor);
        }
    }
}
