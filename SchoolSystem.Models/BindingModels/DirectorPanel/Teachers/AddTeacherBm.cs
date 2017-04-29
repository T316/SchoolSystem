namespace SchoolSystem.Models.BindingModels.DirectorPanel.Teachers
{
    using System.ComponentModel.DataAnnotations;

    public class AddTeacherBm
    {
        [Required(ErrorMessage = "Потребителското име е задължително.")]
        [Display(Name = "Потребителско име")]
        public string UserName { get; set; }
    }
}
