using System.ComponentModel.DataAnnotations;

namespace TravelCore.Models
{
    public class UserSignInViewModel
    {
        [Required(ErrorMessage ="lütfen kullanıcı adını giriniz")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "lütfen parola  giriniz")]
        public string Password { get; set; }

    }
}
