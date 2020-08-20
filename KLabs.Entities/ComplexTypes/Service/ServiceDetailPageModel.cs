using System;
using System.Collections.Generic;
using KLabs.Entities.ComplexTypes.Image;

namespace KLabs.Entities.ComplexTypes.Service
{
    public class ServiceDetailPageModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public List<ImageShowModel> Images { get; set; }

    }
}