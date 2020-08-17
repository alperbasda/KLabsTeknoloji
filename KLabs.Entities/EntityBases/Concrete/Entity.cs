using System;
using System.ComponentModel.DataAnnotations;
using KLabs.Entities.EntityBases.Abstract;

namespace KLabs.Entities.EntityBases.Concrete
{
    public class Entity : IEntity
    {
        [Key]
        public Guid Id { get; set; }

        public DateTime CreationDate { get; set; }
    
    }
}