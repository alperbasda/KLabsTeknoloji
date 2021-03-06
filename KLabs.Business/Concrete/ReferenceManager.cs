﻿using System;
using System.Collections.Generic;
using System.Net;
using AutoMapper;
using DevExtreme.AspNet.Mvc;
using KLabs.Business.Abstract;
using KLabs.Business.Extensions.DevExtremeQueryableExtension;
using KLabs.Core.DataAccess.Abstract;
using KLabs.DataAccess.Abstract;
using KLabs.Entities.ComplexTypes.Reference;
using KLabs.Entities.Concrete;
using KLabs.Entities.Responses;
using Microsoft.EntityFrameworkCore;

namespace KLabs.Business.Concrete
{
    public class ReferenceManager : IReferenceService
    {
        private IReferenceDal _referenceDal;
        private IQueryableRepositoryBase<Reference> _queryable;
        private IMapper _mapper;

        public ReferenceManager(IReferenceDal referenceDal, IQueryableRepositoryBase<Reference> queryable, IMapper mapper)
        {
            _referenceDal = referenceDal;
            _queryable = queryable;
            _mapper = mapper;
        }

        public DataResponse ReferenceList(DataSourceLoadOptions loadOptions)
        {
            return new DataResponse
            {
                Data = _queryable.Table.BindOption(loadOptions),
                Success = true,
                Message = "Referanslar Listelendi",
                StatusCode = HttpStatusCode.OK
            };
        }

        public DataResponse ReferenceById(Guid id)
        {
            var reference = _referenceDal.Get(s => s.Id == id);
            if (reference == null)
                return new DataResponse
                {
                    Success = false,
                    Message = "Referans Bulunamadı",
                    StatusCode = HttpStatusCode.BadRequest,
                };

            return new DataResponse
            {
                Success = true,
                Message = "Referans Detayları",
                StatusCode = HttpStatusCode.OK,
                Data = reference
            };
        }

        public DataResponse AddReference(Reference reference)
        {
            reference.Id = Guid.NewGuid();
            if (_referenceDal.SetState(reference, EntityState.Added))
                return new DataResponse
                {
                    Success = true,
                    Message = "Referans Kayıt Edildi",
                    Data = reference,
                    StatusCode = HttpStatusCode.OK
                };
            return new DataResponse
            {
                Success = false,
                Message = "Referans Kayıt Edilirken Hata Oluştu",
                Data = reference,
                StatusCode = HttpStatusCode.BadRequest
            };
        }

        public DataResponse UpdateReference(Reference reference)
        {
            if (_referenceDal.SetState(reference, EntityState.Modified))
                return new DataResponse
                {
                    Success = true,
                    Message = "Referans Düzenlendi",
                    Data = reference,
                    StatusCode = HttpStatusCode.OK
                };
            return new DataResponse
            {
                Success = false,
                Message = "Referans Düzenlenirken Hata Oluştu",
                Data = reference,
                StatusCode = HttpStatusCode.BadRequest
            };
        }

        public DataResponse DeleteReference(Reference reference)
        {
            if (_referenceDal.SetState(reference, EntityState.Deleted))
                return new DataResponse
                {
                    Success = true,
                    Message = "Referans Kayıt Silindi",
                    Data = reference,
                    StatusCode = HttpStatusCode.OK
                };
            return new DataResponse
            {
                Success = false,
                Message = "Referans Silinirken Hata Oluştu",
                Data = reference,
                StatusCode = HttpStatusCode.BadRequest
            };
        }

        public DataResponse HomePageReferences(int page)
        {
            var take = 8;
            var skip = take * page;
            return new DataResponse
            {
                Data = _mapper.Map<List<HomePageReferenceSwiperModel>>(_referenceDal.GetListSkipTake(skip,take)),
                Success = true,
                Message = $"Referanslar {page}. sayfa",
                StatusCode = HttpStatusCode.OK
            };
        }

    }
}