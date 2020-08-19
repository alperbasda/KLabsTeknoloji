using System.ComponentModel.DataAnnotations;
using KLabs.Entities.EntityBases.Concrete;

namespace KLabs.Entities.Concrete
{
    public class Solution : Entity 
    {
        [Required(ErrorMessage = "Lutfen Çozum Adini Girin")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Lutfen Kisa Aciklama Girin")]
        public string ShortDescription { get; set; }

        [Required(ErrorMessage = "Lutfen Aciklama Girin")]
        public string Description { get; set; }

    }
}