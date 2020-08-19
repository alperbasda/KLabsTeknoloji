using System.ComponentModel.DataAnnotations;
using KLabs.Entities.EntityBases.Concrete;

namespace KLabs.Entities.Concrete
{
    public class Reference : Entity     
    {
        [Required(ErrorMessage = "Referans Adı Girin.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Açıklama Girin.")]
        public string Description { get; set; }

    }
}