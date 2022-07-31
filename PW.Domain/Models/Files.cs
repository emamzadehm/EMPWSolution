using System;

namespace PW.Domain.Models
{
    public class Files
    {
        public long Id { get; private set; }
        public string Title { get; private set; }
        public string FileName { get; private set; }
        public string Description { get; private set; }
        public DateTime UploadDate { get; private set; }
        public int? FileTypeId { get; private set; }
        public long? CourseId { get; private set; }
        public Course Course { get; private set; }
        public bool Status { get; private set; }

        protected Files()
        {

        }

        public Files(string title, string fileName, string description, int? fileTypeId, long? courseId)
        {
            Title = title;
            FileName = fileName;
            Description = description;
            FileTypeId = fileTypeId;
            UploadDate = DateTime.Now;
            CourseId = courseId;
            Status = true;
        }
        public void Edit(string title, string fileName, string description, int? fileTypeId, long? courseId)
        {
            Title = title;
            FileName = fileName;
            Description = description;
            FileTypeId = fileTypeId;
            CourseId = courseId;
        }
        public void Remove()
        {
            Status = false;
        }
    }
}
