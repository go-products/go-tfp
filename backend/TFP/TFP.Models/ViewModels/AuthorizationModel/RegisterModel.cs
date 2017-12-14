using System.ComponentModel.DataAnnotations;

namespace TFP.Models.ViewModels.AuthorizationModel
{
    public class RegisterModel
    {
        [Required]
        [MinLength(2)]
        public string FirsName { get; set; }

        [Required]
        [MinLength(2)]
        public string LastName { get; set; }

        [Required]
        [MinLength(3)]
        public string Password { get; set; }

        [Required]
        [MinLength(3)]
        public string ConfirmPassword { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        public string UserName { get; set; }
    }
}
