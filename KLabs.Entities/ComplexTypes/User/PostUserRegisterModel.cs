using System.ComponentModel.DataAnnotations;
using KLabs.Entities.EntityBases.Concrete;

namespace KLabs.Entities.ComplexTypes.User
{
    public class PostUserRegisterModel : PostModel
    {
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Lütfen Mail Adresinizi Girin")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Lütfen Şifrenizi Girin")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Lütfen Şifrenizi Tekrar Girin")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Şifreler Eşleşmiyor")]
        public string PasswordConfirm { get; set; }

        [Required(ErrorMessage = "Lütfen Adınızı Girin")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Lütfen Soyadınızı Girin")]
        public string LastName { get; set; }
    }
}