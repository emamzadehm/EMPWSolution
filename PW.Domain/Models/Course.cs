using System.Collections.Generic;

namespace PW.Domain.Models
{
    public class Course
    {

        public long Id { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public bool ShowInWebSite { get; private set; }
        public bool Status { get; private set; }
        public ICollection<Files> Files { get; private set; }

        protected Course()
        {

        }
        public Course(string title, string description, bool showinwebsite)
        {
            Title = title;
            Description = description;
            ShowInWebSite = showinwebsite;
            Status = true;
        }
        public void Edit(string title, string description, bool showinwebsite)
        {
            Title = title;
            Description = description;
            ShowInWebSite = showinwebsite;
        }
        public void Remove()
        {
            Status = false;
        }
    }
}
