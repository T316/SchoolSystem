using System;
using System.ComponentModel.DataAnnotations;

namespace SchoolSystem.Models.EntityModels
{
    public class Note
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Полето е задължително.")]
        [MaxLength(200, ErrorMessage = "Забележката трябва да е максимум 200 символа.")]
        public string Content { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public virtual Teacher Teacher { get; set; }

        [Required]
        public virtual Student Student { get; set; }
    }
}
