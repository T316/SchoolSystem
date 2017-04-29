namespace SchoolSystem.Models.EntityModels
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Mark
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Полето е задължително.")]
        [Range(2, 6, ErrorMessage = "Стойността трябва да е между 2 и 6.")]
        public int Value { get; set; }

        [Required]
        public virtual Subject Subject { get; set; }

        [Required]
        public virtual Student Student { get; set; }

        [Required]
        public DateTime Date { get; set; }
    }
}
