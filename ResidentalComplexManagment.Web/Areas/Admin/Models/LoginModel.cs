using System.ComponentModel.DataAnnotations;

namespace ResidentalComplexManagment.Web.Areas.Admin.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "login yazılmıyıb")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "parol yazılmıyıb")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Yadda Saxlamaq?")]
        public bool RememberMe { get; set; }

        public string ReturnUrl { get; set; }
    }
}
