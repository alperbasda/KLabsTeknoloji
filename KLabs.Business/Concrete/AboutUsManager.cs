using System.Net;
using KLabs.Business.Abstract;
using KLabs.Business.Constants.Statics;
using KLabs.DataAccess.Abstract;
using KLabs.Entities.Concrete;
using KLabs.Entities.Responses;
using Microsoft.EntityFrameworkCore;

namespace KLabs.Business.Concrete
{
    public class AboutUsManager : IAboutUsService
    {
        private IAboutUsDal _aboutUsDal;

        public AboutUsManager(IAboutUsDal aboutUsDal)
        {
            _aboutUsDal = aboutUsDal;
        }

        public DataResponse GetAboutUs()
        {
            var data = StaticMember.AboutUs??_aboutUsDal.First();
            
            if (data == null)
                return new DataResponse
                {
                    Success = false,
                    Message = "İçerik Bulunamadı",
                    StatusCode = HttpStatusCode.NotFound
                };

            if (StaticMember.AboutUs == null)
                StaticMember.AboutUs = data;

            return new DataResponse
            {
                Success = true,
                Message = "Hakkımızda Bilgisi",
                StatusCode = HttpStatusCode.OK,
                Data = data
            };
        }

        public DataResponse UpdateAboutUs(AboutUs aboutUs)
        {
            if (_aboutUsDal.SetState(aboutUs, EntityState.Modified))
            {
                StaticMember.AboutUs = aboutUs;
                return new DataResponse
                {
                    Success = true,
                    Message = "Hakkımızda Bilgileri Güncellendi",
                    StatusCode = HttpStatusCode.Created,
                    Data = aboutUs
                };
            }
                

            return new DataResponse
            {
                Success = false,
                Message = "Hakkımızda Bilgileri Düzenlenirken Hata Oluştu",
                StatusCode = HttpStatusCode.BadRequest
            };
        }
    }
}