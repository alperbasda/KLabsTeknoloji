using System.Net;
using KLabs.Business.Abstract;
using KLabs.Business.Constants.Statics;
using KLabs.DataAccess.Abstract;
using KLabs.Entities.Concrete;
using KLabs.Entities.Responses;
using Microsoft.EntityFrameworkCore;

namespace KLabs.Business.Concrete
{
    public class PrivacyManager : IPrivacyService
    {
        private IPrivacyDal _privacyDal;

        public PrivacyManager(IPrivacyDal privacyDal)
        {
            _privacyDal = privacyDal;
        }

        public DataResponse GetPrivacy()
        {
            var data =_privacyDal.First();

            if (data == null)
                return new DataResponse
                {
                    Success = false,
                    Message = "İçerik Bulunamadı",
                    StatusCode = HttpStatusCode.NotFound
                };

            return new DataResponse
            {
                Success = true,
                Message = "Gizlilik Sözleşmesi",
                StatusCode = HttpStatusCode.OK,
                Data = data
            };
        }

        public DataResponse UpdatePrivacy(Privacy privacy)
        {
            if (_privacyDal.SetState(privacy, EntityState.Modified))
            {
                return new DataResponse
                {
                    Success = true,
                    Message = "Gizlilik Sözleşmesi Güncellendi",
                    StatusCode = HttpStatusCode.Created,
                    Data = privacy
                };
            }


            return new DataResponse
            {
                Success = false,
                Message = "Gizlilik Sözleşmesi Düzenlenirken Hata Oluştu",
                StatusCode = HttpStatusCode.BadRequest
            };
        }
    }
}