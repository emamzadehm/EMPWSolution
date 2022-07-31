using Microsoft.AspNetCore.Mvc.RazorPages;
using PW.ApplicationContracts.Interfaces;
using PW.ApplicationContracts.ViewModels;
using System.Collections.Generic;

namespace PW.UI.Pages
{
    public class ViewFilesModel : PageModel
    {
        private readonly IFileApplication _ifile_application;

        public ViewFilesModel(IFileApplication ifile_application)
        {
            _ifile_application = ifile_application;
        }

        public List<FileViewModel> FileVM { get; set; }
        public FileViewModel SearchModel { get; set; }

        public void OnGet(int Id)
        {
            ViewData["id"] = Id;
            FileVM = _ifile_application.GetbyType(Id);
        }

    }
}
