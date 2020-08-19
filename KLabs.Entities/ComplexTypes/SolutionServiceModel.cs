using System;
using KLabs.Entities.Enums;

namespace KLabs.Entities.ComplexTypes
{
    public class SolutionServiceModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public MenuType MenuType { get; set; }

    }
}