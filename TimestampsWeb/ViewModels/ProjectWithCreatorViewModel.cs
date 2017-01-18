using System;

namespace TimestampsWeb.ViewModels
{
    public class ProjectWithCreatorViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string CreatorName { get; set; }
        public DateTime CreationDate { get; set; }
    }
}