using System;

namespace PW.Domain.Models
{
    public class Testimonial
    {
        public long Id { get; private set; }
        public string StudentName { get; private set; }
        public string StudentImg { get; private set; }
        public string StudentEmail { get; private set; }
        public string CourseName { get; private set; }
        public string UniversityName { get; private set; }
        public int EduYear { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public bool IsVisible { get; private set; }
        public bool Status { get; private set; }
        public DateTime CreatedDate { get; private set; }

        protected Testimonial()
        {

        }

        public Testimonial(string studentName, string studentImg, string studentEmail, string courseName, string universityName, int eduYear, string title, string description)
        {
            StudentName = studentName;
            StudentImg = studentImg;
            StudentEmail = studentEmail;
            CourseName = courseName;
            UniversityName = universityName;
            EduYear = eduYear;
            Title = title;
            Description = description;
            CreatedDate = DateTime.Now;
            IsVisible = false;
            Status = true;
        }

        public void ToVisible()
        {
            IsVisible = true;
        }
        public void ToInvisible()
        {
            IsVisible = false;
        }
        public void Remove ()
        {
            Status = false;
        }
    }
}
