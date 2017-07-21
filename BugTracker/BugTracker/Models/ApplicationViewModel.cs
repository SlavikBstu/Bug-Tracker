using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BugTracker.Models
{
    public class ApplicationViewModel
    {
        [Required]
        [Display(Name = "Тема заявки")]
        public string Caption { get; set; }

        [Required]
        [Display(Name = "Тип заявки")]
        public string Type { get; set; }

        [Required]
        [Display(Name = "Приоритет заявки")]
        public string Priority { get; set; }

        [Required]
        [StringLength(500, ErrorMessage = "Значение {0} должно содержать не менее {2} символов.", MinimumLength = 10)]
        [Display(Name = "Комментарий пользователя")]
        public string Annotation { get; set; }

        [Display(Name = "Изображение неисправности")]
        public string Picture { get; set; }
    }
}