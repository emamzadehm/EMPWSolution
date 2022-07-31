using Microsoft.AspNetCore.Mvc.RazorPages;
using PW.ApplicationContracts.Interfaces;
using PW.ApplicationContracts.ViewModels;

namespace PW.UI.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IMessageApplication _imessageapplication;

        public IndexModel(IMessageApplication imessageapplication)
        {
            _imessageapplication = imessageapplication;
        }

        //[BindProperty(SupportsGet = true)]
        public MessageViewModel Message { get; set; }
        public string ErrorMessage { get; set; }
        public string SuccessMessage { get; set; }
        public void OnGet()
        {

        }
        public void OnPost(MessageViewModel message)
        {
            if (!ModelState.IsValid)
            {
                ErrorMessage = "اطلاعات ثبت نگردید. لطفاً مجدداً تلاش نمائید.";
            }
            else 
            { 
            _imessageapplication.Create(message);
            SuccessMessage = "اطلاعات با موفقیت ثبت گردید. با تشکر.";
            ModelState.Clear();
            }
        }
    }
}