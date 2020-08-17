using KLabs.Entities.EntityBases.Concrete;

namespace KLabs.Entities.Concrete
{
    public class Reference : Entity     
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string ImagePath { get; set; }
    }
}