using System.ComponentModel.DataAnnotations;
using KLabs.Entities.EntityBases.Concrete;

namespace KLabs.Entities.Concrete
{
    public class Privacy : Entity       
    {
        [Required(ErrorMessage = "Lütfen Açıklama Girin")]
        public string Description { get; set; }

    }
}