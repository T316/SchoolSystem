namespace SchoolSystem.Models.EntityModels
{
    using System.ComponentModel.DataAnnotations;

    public class Subject
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Полето е задължително.")]
        [MaxLength(30, ErrorMessage = "Името на предмета трябва да е максимум 30 символа.")]
        public string Name { get; set; }

        public virtual Grade Grade { get; set; }

        public virtual Teacher Teacher { get; set; }
    }
}
