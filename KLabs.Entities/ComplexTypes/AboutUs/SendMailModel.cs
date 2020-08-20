using System.ComponentModel.DataAnnotations;

namespace KLabs.Entities.ComplexTypes.AboutUs
{
    public class SendMailModel
    {
        [Required(ErrorMessage = "Lütfen Adınızı ve Soyadınızı Girin")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Lütfen Mail Adresinizi Girin")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Lütfen Telefon Numaranızı Girin")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Lütfen Mesaj Konusunu Girin")]
        public string Subject { get; set; }

        [Required(ErrorMessage = "Lütfen Mesaj İçeriğini Girin")]
        public string Description { get; set; }

    }
}