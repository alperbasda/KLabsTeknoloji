using System;
using KLabs.Entities.Enums;

namespace KLabs.Entities.ComplexTypes.Image
{
    public class ImageOperationAdminModel
    {
        public Guid Id { get; set; }

        public ImageType ImageType { get; set; }

    }
}