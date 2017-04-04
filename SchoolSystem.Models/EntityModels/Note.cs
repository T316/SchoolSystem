using System;

namespace SchoolSystem.Models.EntityModels
{
    public class Note
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public DateTime Date { get; set; }

        public virtual Teacher Teacher { get; set; }

        public virtual Student Student { get; set; }
    }
}
