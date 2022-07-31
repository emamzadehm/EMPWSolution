using Microsoft.AspNetCore.Mvc;
using PW.ApplicationContracts.Interfaces;
using System.Linq;

namespace Emamzadeh.ViewComponents
{
    public class FileViewComponent : ViewComponent
    {
        private readonly IFileApplication _ifileapplication;

        public FileViewComponent(IFileApplication ifileapplication)
        {
            _ifileapplication = ifileapplication;
        }

        public IViewComponentResult Invoke(int Id)
        {
            var fileslist = _ifileapplication.Search(null).Where(x=>x.FileTypeId == Id);
            return View("_Files",fileslist);
        }
    }
}
