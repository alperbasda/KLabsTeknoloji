using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using AutoMapper;
using DevExtreme.AspNet.Mvc;
using KLabs.Business.Abstract;
using KLabs.Business.Constants.Statics;
using KLabs.Business.Extensions.DevExtremeQueryableExtension;
using KLabs.Core.DataAccess.Abstract;
using KLabs.DataAccess.Abstract;
using KLabs.Entities.ComplexTypes;
using KLabs.Entities.ComplexTypes.Solution;
using KLabs.Entities.Concrete;
using KLabs.Entities.Enums;
using KLabs.Entities.Responses;
using Microsoft.EntityFrameworkCore;

namespace KLabs.Business.Concrete
{
    public class SolutionManager : ISolutionService
    {
        private ISolutionDal _solutionDal;
        private IQueryableRepositoryBase<Solution> _queryable;
        private IMapper _mapper;

        public SolutionManager(ISolutionDal solutionDal, IQueryableRepositoryBase<Solution> queryable, IMapper mapper)
        {
            _solutionDal = solutionDal;
            _queryable = queryable;
            _mapper = mapper;
        }

        public DataResponse SolutionList(DataSourceLoadOptions loadOptions)
        {
            return new DataResponse
            {
                Data = _queryable.Table.BindOption(loadOptions),
                Success = true,
                Message = "Çözümler Listelendi",
                StatusCode = HttpStatusCode.OK
            };
        }

        public DataResponse SolutionById(Guid id)
        {
            var solution = _solutionDal.Get(s => s.Id == id);
            if (solution == null)
                return new DataResponse
                {
                    Success = false,
                    Message = "Çözüm Bulunamadı",
                    StatusCode = HttpStatusCode.BadRequest,
                };

            return new DataResponse
            {
                Success = true,
                Message = "Çözüm Detayları",
                StatusCode = HttpStatusCode.OK,
                Data = solution
            };
        }

        public DataResponse AddSolution(Solution solution)
        {
            solution.Id = Guid.NewGuid();
            if (_solutionDal.SetState(solution, EntityState.Added))
            {
                StaticMember.MenuModels.Add(new SolutionServiceModel
                {
                    Id = solution.Id,
                    MenuType = MenuType.Solution,
                    Name = solution.Name
                });
                return new DataResponse
                {
                    Success = true,
                    Message = "Çözüm Kayıt Edildi",
                    Data = solution,
                    StatusCode = HttpStatusCode.OK
                };
            }
                
            return new DataResponse
            {
                Success = false,
                Message = "Çözüm Kayıt Edilirken Hata Oluştu",
                Data = solution,
                StatusCode = HttpStatusCode.BadRequest
            };
        }

        public DataResponse UpdateSolution(Solution solution)
        {
            if (_solutionDal.SetState(solution, EntityState.Modified))
            {
                var staticSolution = StaticMember.MenuModels.First(s => s.Id == solution.Id && s.MenuType==MenuType.Solution);
                staticSolution.Id = solution.Id;
                staticSolution.Name = solution.Name;
                return new DataResponse
                {
                    Success = true,
                    Message = "Çözüm Düzenlendi",
                    Data = solution,
                    StatusCode = HttpStatusCode.OK
                };
            }
                
            return new DataResponse
            {
                Success = false,
                Message = "Çözüm Düzenlenirken Hata Oluştu",
                Data = solution,
                StatusCode = HttpStatusCode.BadRequest
            };
        }

        public DataResponse DeleteSolution(Solution solution)
        {
            if (_solutionDal.SetState(solution, EntityState.Deleted))
            {
                StaticMember.MenuModels.RemoveAll(s => s.Id == solution.Id && s.MenuType == MenuType.Solution);
                return new DataResponse
                {
                    Success = true,
                    Message = "Çözüm Kayıt Silindi",
                    Data = solution,
                    StatusCode = HttpStatusCode.OK
                };
            }
                
            return new DataResponse
            {
                Success = false,
                Message = "Çözüm Silinirken Hata Oluştu",
                Data = solution,
                StatusCode = HttpStatusCode.BadRequest
            };
        }

        public DataResponse StaticSolutions()
        {
            if (StaticMember.MenuModels.Any(s => s.MenuType == MenuType.Solution))
                return new DataResponse
                {
                    Success = true,
                    Message = "Menu Items",
                    Data = StaticMember.MenuModels.Where(s => s.MenuType == MenuType.Solution).ToList()
                };

            return new DataResponse
            {
                Success = true,
                Message = "Menu Items",
                Data = _solutionDal.GetList().Select(s => new SolutionServiceModel
                {
                    Name = s.Name,
                    MenuType = MenuType.Solution,
                    Id = s.Id
                }).ToList()
            };

        }

        public DataResponse HomePageSolutions(int page)
        {
            var take = 3;
            var skip = page * take;
            return new DataResponse
            {
                Success = true,
                Data = _mapper.Map<List<HomePageSolutionModel>>(_solutionDal.GetListSkipTake(skip, take)),
                Message = $"Anasayfa Çözümler {page}. Sayfa",
                StatusCode = HttpStatusCode.OK
            };
            
        }
    }
}
