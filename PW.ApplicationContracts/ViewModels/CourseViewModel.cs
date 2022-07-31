namespace PW.ApplicationContracts.ViewModels
{
    public class CourseViewModel
    {

        public long Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool ShowInWebSite { get; set; }
        public bool Status { get; set; }

    }
}
