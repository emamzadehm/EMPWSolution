using _01_Framework.Infrastructure.EFCore;
using Microsoft.AspNetCore.Hosting;
using PW.ApplicationContracts.ViewModels;
using PW.Domain.IRepository;
using PW.Domain.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace PW.Infrastructure.EFCore.Repository
{
    public class FileRepository : BaseRepository<long, Files>, IFileRepository
    {
        private readonly EMContext _emcontext;
        private readonly IHostingEnvironment _hostingEnvironment;

        public FileRepository(EMContext emcontext, IHostingEnvironment hostingEnvironment) : base(emcontext)
        {
            _emcontext = emcontext;
            _hostingEnvironment = hostingEnvironment;
        }

        public List<FileViewModel> Search(FileViewModel command = null)
        {
            var Query = _emcontext.Files.Where(x => x.Status).Select(listitem => new FileViewModel
            {
                Id = listitem.Id,
                Title = listitem.Title,
                FileName = listitem.FileName,
                FileExtention = Path.GetExtension(listitem.FileName),
                FileLenght = (new FileInfo(Path.Combine(_hostingEnvironment.WebRootPath, "uploads" , listitem.FileName)).Length)/1024,
                FileTypeId = listitem.FileTypeId,
                UploadDate = listitem.UploadDate,
                CourseId = listitem.CourseId,
                CourseIdTitle = listitem.Course.Title,
                Description = listitem.Description
            });
            if (command != null)
            {
                if (!string.IsNullOrWhiteSpace(command.Description))
                    Query = Query.Where(x => x.Description.Contains(command.Description) || x.Title.Contains(command.Title));
                if (command.Id > 0)
                    Query = Query.Where(x => x.Id == command.Id);
                if (command.FileTypeId > 0)
                    Query = Query.Where(x => x.FileTypeId == command.FileTypeId);
                if (command.CourseId > 0)
                    Query = Query.Where(x => x.CourseId == command.CourseId);
            }
            return Query.OrderBy(x => x.Id).ToList();
        }
        public FileViewModel GetDetails(long Id)
        {
            return _emcontext.Files.Where(x => x.Status == true).Select(listitem => new FileViewModel
            {
                Id = listitem.Id,
                Title = listitem.Title,
                FileName = listitem.FileName,
                FileExtention = Path.GetExtension(listitem.FileName),
                FileLenght = (new FileInfo(Path.Combine(_hostingEnvironment.WebRootPath, "uploads", listitem.FileName)).Length) / 1024,
                FileTypeId = listitem.FileTypeId,
                UploadDate = listitem.UploadDate,
                CourseId = listitem.CourseId,
                CourseIdTitle = listitem.Course.Title,
                Description = listitem.Description
            }).FirstOrDefault(x => x.Id == Id);
        }

        public List<FileViewModel> GetbyType(int Id)
        {
            var Query = _emcontext.Files.Where(x => x.Status == true).Select(listitem => new FileViewModel
            {
                Id = listitem.Id,
                Title = listitem.Title,
                FileName = listitem.FileName,
                FileExtention = Path.GetExtension(listitem.FileName),
                FileLenght = (new FileInfo(Path.Combine(_hostingEnvironment.WebRootPath, "uploads", listitem.FileName)).Length) / 1024,
                FileTypeId = listitem.FileTypeId,
                UploadDate = listitem.UploadDate,
                CourseId = listitem.CourseId,
                CourseIdTitle = listitem.Course.Title,
                Description = listitem.Description
            }).Where(x => x.FileTypeId == Id);
            return Query.OrderByDescending(x => x.Id).ToList();
        }
    }
}
