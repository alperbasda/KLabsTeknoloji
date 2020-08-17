using System;

namespace KLabs.Entities.EntityBases.Abstract
{
    public interface IEntity
    {
        Guid Id { get; set; }

        public DateTime CreationDate { get; set; }
    }
}