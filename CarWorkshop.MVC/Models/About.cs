namespace CarWorkshop.MVC.Models
{
    public class About
    {
        public About(string title, string description, string[] tags)
        {
            Title = title;
            Description = description;
            Tags = tags;
        }
        public string Title { get; set; }
        public string Description { get; set; }
        public string[] Tags { get; set; }
    }
}
