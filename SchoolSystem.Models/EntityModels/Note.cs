namespace SchoolSystem.Models.EntityModels
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Note
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Полето е задължително.")]
        [MaxLength(50, ErrorMessage = "Бележката трябва да е максимум 50 символа.")]
        public string Content { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public virtual Teacher Teacher { get; set; }

        [Required]
        public virtual Student Student { get; set; }
    }
}
