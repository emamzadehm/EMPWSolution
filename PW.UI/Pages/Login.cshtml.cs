using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UM.Application.Contracts.Interfaces;
using UM.Application.Contracts.ViewModels;

namespace PW.UI.Pages
{
    public class LoginModel : PageModel
    {
        [TempData]
        public string Message { get; set; }
        private readonly IUserApplication _iuserapplication;
        public LoginModel(IUserApplication iuserapplication)
        {
            _iuserapplication = iuserapplication;
        }

        public void OnGet()
        {

        }
        public IActionResult OnPost(LoginViewModel command)
        {
            var result = _iuserapplication.Login(command);
            if (result.isSuccessful)
            {
                return RedirectToPage("/Index", new { area = "AdminPanel" });

            }
            else
            { 
            Message = result.message;
            return RedirectToPage("/Login");
            }
        }
        public RedirectToPageResult OnGetLogOut()
        {
            _iuserapplication.Logout();
            return RedirectToPage("/Login");
        }
    }
}
