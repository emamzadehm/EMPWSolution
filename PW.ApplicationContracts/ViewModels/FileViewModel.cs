using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;

namespace PW.ApplicationContracts.ViewModels
{
    public class FileViewModel
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string FileName { get; set; }
        public IFormFile FileContent { get; set; }
        public string FileExtention { get; set; }
        public long FileLenght { get; set; }
        public string Description { get; set; }
        public DateTime UploadDate { get; set; }
        public int? FileTypeId { get; set; }
        public long? CourseId { get; set; }
        public string CourseIdTitle { get; set; }
        public bool Status { get; set; }
        public List<CourseViewModel> CourseList { get; set; }

    }
}
