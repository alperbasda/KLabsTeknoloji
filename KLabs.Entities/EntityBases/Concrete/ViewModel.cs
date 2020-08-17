using System;
using KLabs.Entities.EntityBases.Abstract;

namespace KLabs.Entities.EntityBases.Concrete
{
    public class ViewModel : IViewModel
    {
        public Guid Id { get; set; }

        public DateTime CreationDate { get; set; }
    }
}