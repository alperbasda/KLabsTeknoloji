using System.Collections.Generic;
using KLabs.Business.Abstract;
using KLabs.Business.Constants.Statics;
using KLabs.Entities.ComplexTypes;
using KLabs.Entities.Concrete;

namespace KLabs.Business.Concrete
{
    public class CacheManager : ICacheService
    {
        private ISolutionService _solutionService;
        private IServiceService _serviceService;
        private IAboutUsService _aboutUsService;

        public CacheManager(
            ISolutionService solutionService, 
            IServiceService serviceService, 
            IAboutUsService aboutUsService
            )
        {
            _solutionService = solutionService;
            _serviceService = serviceService;
            _aboutUsService = aboutUsService;
        }

        public void FillData()
        {
            StaticMember.MenuModels = (List<SolutionServiceModel>) _serviceService.StaticServices().Data;
            StaticMember.MenuModels.AddRange((List<SolutionServiceModel>)_solutionService.StaticSolutions().Data);
            StaticMember.AboutUs = (AboutUs)_aboutUsService.GetAboutUs().Data;

        }
    }
}