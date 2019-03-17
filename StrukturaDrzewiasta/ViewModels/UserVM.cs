using System.ComponentModel.DataAnnotations;

namespace StrukturaDrzewiasta.ViewModels
{
    public class UserVM
    {
        [Required]
        [Display(Name = "Username")]
        [StringLength(20)]
        public string UserName { get; set; }

        [Display(Name = "First Name")]
        [StringLength(20)]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [StringLength(20)]
        public string LastName { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "The e-mail address is not valid.")]
        [StringLength(30)]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(20, ErrorMessage = "The password is too long.")]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "Invalid password confirmation.")]
        public string ConfirmPassword { get; set; }
    }
}