using System.ComponentModel.DataAnnotations;

namespace StrukturaDrzewiasta.ViewModels
{
    public class LoginVM
    {
        [Required(ErrorMessage = "User Name is required.")]
        [Display(Name = "User Name")]
        public string UserName { get; set; }
        
        [Required(ErrorMessage = "Password is required.")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}