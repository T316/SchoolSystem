﻿namespace SchoolSystem.Models.EntityModels
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Teacher
    {
        public Teacher()
        {
            this.Subjects = new HashSet<Subject>();
        }

        [Key]
        public int Id { get; set; }

        public virtual User User { get; set; }

        public virtual ICollection<Subject> Subjects { get; set; }
    }
}
