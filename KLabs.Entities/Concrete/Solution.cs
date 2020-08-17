using KLabs.Entities.EntityBases.Concrete;

namespace KLabs.Entities.Concrete
{
    public class Solution : Entity
    {
        public string Name { get; set; }

        public string ImagePath { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

    }
}