using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PW.ApplicationContracts.Interfaces;
using PW.ApplicationContracts.ViewModels;

namespace PW.UI.Areas.AdminPanel.Pages.SiteManagement.Message
{
    public class IndexModel : PageModel
    {

        private readonly IMessageApplication _imessage_application;

        public List<MessageViewModel> MessageVM { get; set; }
        public MessageViewModel SearchModel { get; set; }

        public IndexModel(IMessageApplication icourse_application)
        {
            _imessage_application = icourse_application;
        }

        public void OnGet(MessageViewModel searchmodel)
        {
            MessageVM = _imessage_application.Search(searchmodel);
        }
        public IActionResult OnGetCreate()
        {
            var command = new MessageViewModel();
            return Partial("./Create", command);
        }
        public JsonResult OnPostCreate(MessageViewModel coursevm)
        {
            var result = _imessage_application.Create(coursevm);
            return new JsonResult(result);
        }
        public IActionResult OnGetRemove(MessageViewModel coursevm)
        {
            _imessage_application.Remove(coursevm.Id);
            return RedirectToPage("Index");
        }
        public IActionResult OnGetEmail(MessageViewModel coursevm)
        {
            _imessage_application.SendToEmail(coursevm);
            return RedirectToPage("Index");
        }

    }
}
