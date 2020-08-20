using System.Collections.Generic;
using KLabs.Entities.ComplexTypes;
using KLabs.Entities.Concrete;

namespace KLabs.Business.Constants.Statics
{
    public static class StaticMember
    {
        public static AboutUs AboutUs { get; set; }

        public static string LogoPath { get; set; }

        public static string FavPath { get; set; }

        public static List<SolutionServiceModel> MenuModels = new List<SolutionServiceModel>();
    }
}