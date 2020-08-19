using System;
using DevExtreme.AspNet.Mvc;
using KLabs.Entities.Concrete;
using KLabs.Entities.Responses;

namespace KLabs.Business.Abstract
{
    public interface IServiceService
    {
        DataResponse ServiceList(DataSourceLoadOptions loadOptions);

        DataResponse ServiceById(Guid id);

        DataResponse AddService(Service service);

        DataResponse UpdateService(Service service);

        DataResponse DeleteService(Service service);

        DataResponse StaticServices();
    }
}