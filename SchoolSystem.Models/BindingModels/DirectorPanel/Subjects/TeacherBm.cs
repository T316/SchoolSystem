namespace SchoolSystem.Models.BindingModels.DirectorPanel.Subjects
{
    using System.ComponentModel.DataAnnotations;

    public class TeacherBm
    {
        [Required(ErrorMessage = "Потребителското име е задължително.")]
        [Display(Name = "Потребителско име")]
        public string UserName { get; set; }
    }
}
