﻿namespace ProjectManager.Models
{
    public class TaskDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public string Status { get; set; }
        public Project? Project { get; set; }
    }
}
