using System;
using System.Linq;
using System.Net;
using DevExtreme.AspNet.Mvc;
using KLabs.Business.Abstract;
using KLabs.Business.Constants.Statics;
using KLabs.Business.Extensions.DevExtremeQueryableExtension;
using KLabs.Core.DataAccess.Abstract;
using KLabs.DataAccess.Abstract;
using KLabs.Entities.ComplexTypes;
using KLabs.Entities.Concrete;
using KLabs.Entities.Enums;
using KLabs.Entities.Responses;
using Microsoft.EntityFrameworkCore;

namespace KLabs.Business.Concrete
{
    public class ServiceManager : IServiceService
    {
        private IServiceDal _serviceDal;
        private IQueryableRepositoryBase<Service> _queryable;

        public ServiceManager(IServiceDal serviceDal, IQueryableRepositoryBase<Service> queryable)
        {
            _serviceDal = serviceDal;
            _queryable = queryable;
        }

        public DataResponse ServiceList(DataSourceLoadOptions loadOptions)
        {
            return new DataResponse
            {
                Data = _queryable.Table.BindOption(loadOptions),
                Success = true,
                Message = "Hizmetler Listelendi",
                StatusCode = HttpStatusCode.OK
            };
        }

        public DataResponse ServiceById(Guid id)
        {
            var service = _serviceDal.Get(s => s.Id == id);
            if (service == null)
                return new DataResponse
                {
                    Success = false,
                    Message = "Hizmet Bulunamadı",
                    StatusCode = HttpStatusCode.BadRequest,
                };

            return new DataResponse
            {
                Success = true,
                Message = "Hizmet Detayları",
                StatusCode = HttpStatusCode.OK,
                Data = service
            };
        }

        public DataResponse AddService(Service service)
        {
            service.Id = Guid.NewGuid();
            if (_serviceDal.SetState(service, EntityState.Added))
            {
                StaticMember.MenuModels.Add(new SolutionServiceModel
                {
                    Id = service.Id,
                    MenuType = MenuType.Service,
                    Name = service.Name
                });
                return new DataResponse
                {
                    Success = true,
                    Message = "Hizmet Kayıt Edildi",
                    Data = service,
                    StatusCode = HttpStatusCode.OK
                };
            }

            return new DataResponse
            {
                Success = false,
                Message = "Hizmet Kayıt Edilirken Hata Oluştu",
                Data = service,
                StatusCode = HttpStatusCode.BadRequest
            };
        }

        public DataResponse UpdateService(Service service)
        {
            if (_serviceDal.SetState(service, EntityState.Modified))
            {
                var staticService = StaticMember.MenuModels.First(s => s.Id == service.Id && s.MenuType == MenuType.Service);
                staticService.Id = service.Id;
                staticService.Name = service.Name;
                return new DataResponse
                {
                    Success = true,
                    Message = "Hizmet Düzenlendi",
                    Data = service,
                    StatusCode = HttpStatusCode.OK
                };
            }

            return new DataResponse
            {
                Success = false,
                Message = "Hizmet Düzenlenirken Hata Oluştu",
                Data = service,
                StatusCode = HttpStatusCode.BadRequest
            };
        }

        public DataResponse DeleteService(Service service)
        {
            if (_serviceDal.SetState(service, EntityState.Deleted))
            {
                StaticMember.MenuModels.RemoveAll(s => s.Id == service.Id && s.MenuType == MenuType.Service);
                return new DataResponse
                {
                    Success = true,
                    Message = "Hizmet Kayıt Silindi",
                    Data = service,
                    StatusCode = HttpStatusCode.OK
                };
            }

            return new DataResponse
            {
                Success = false,
                Message = "Hizmet Silinirken Hata Oluştu",
                Data = service,
                StatusCode = HttpStatusCode.BadRequest
            };
        }

        public DataResponse StaticServices()
        {
            if (StaticMember.MenuModels.Any(s => s.MenuType == MenuType.Service))
                return new DataResponse
                {
                    Success = true,
                    Message = "Menu Items",
                    Data = StaticMember.MenuModels.Where(s => s.MenuType == MenuType.Service).ToList()
                };

            return new DataResponse
            {
                Success = true,
                Message = "Menu Items",
                Data = _serviceDal.GetList().Select(s => new SolutionServiceModel
                {
                    Name = s.Name,
                    MenuType = MenuType.Service,
                    Id = s.Id
                }).ToList()
            };

        }
    }
}