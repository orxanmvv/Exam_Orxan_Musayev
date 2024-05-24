

using System.ComponentModel.DataAnnotations;

namespace WebApplication5.ViewModels.Account
{
    public class LoginVm
    {
        [Required]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
       
        public bool RememberMe { get; set; } 
    }
}
