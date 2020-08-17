using System;
using KLabs.Entities.EntityBases.Abstract;

namespace KLabs.Entities.EntityBases.Concrete
{
    public class PostModel : IPostModel
    {
        public DateTime CreationDate => DateTime.Now;

    }
}