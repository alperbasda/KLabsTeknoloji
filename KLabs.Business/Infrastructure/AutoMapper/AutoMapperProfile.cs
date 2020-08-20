using AutoMapper;
using KLabs.Entities.ComplexTypes.Reference;
using KLabs.Entities.ComplexTypes.Service;
using KLabs.Entities.ComplexTypes.Solution;
using KLabs.Entities.Concrete;

namespace KLAbs.Business.Infrastructure.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Solution, HomePageSolutionModel>()
                .ForMember(s => s.ImagePath, w => w.Ignore());

            CreateMap<Reference, HomePageReferenceSwiperModel>()
                .ForMember(s => s.LogoPath, w => w.Ignore());

            CreateMap<Solution, SolutionDetailPageModel>()
                .ForMember(s => s.Images, w => w.Ignore());

            CreateMap<Service, ServiceDetailPageModel>()
                .ForMember(s => s.Images, w => w.Ignore());

        }
    }
}
