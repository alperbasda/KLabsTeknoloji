using System.ComponentModel.DataAnnotations;
using KLabs.Entities.EntityBases.Concrete;

namespace KLabs.Entities.ComplexTypes.User
{
    public class PostUserLoginModel : PostModel
    {
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Lütfen Mail Adresinizi Girin")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Lütfen Şifrenizi Girin")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}