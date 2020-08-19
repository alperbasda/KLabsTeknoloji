using System.ComponentModel.DataAnnotations;
using KLabs.Entities.EntityBases.Concrete;

namespace KLabs.Entities.Concrete
{
    public class AboutUs : Entity
    {
        [Required(ErrorMessage = "Açıklama Alanı Zorunludur.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Telefon Numarası Zorunludur.")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Mail Adresi Zorunludur.")]
        [DataType(DataType.EmailAddress)]
        public string MailAddress { get; set; }

        [Required(ErrorMessage = "Adres Alanı Zorunludur.")]
        public string Address { get; set; }

        public string TwitterLink { get; set; }

        public string FacebookLink { get; set; }

        public string InsLink { get; set; }

        public string LinkedLink { get; set; }

    }
}