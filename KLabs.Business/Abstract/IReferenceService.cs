using System;
using System.Collections.Generic;
using DevExtreme.AspNet.Mvc;
using KLabs.Entities.ComplexTypes.User;
using KLabs.Entities.Concrete;
using KLabs.Entities.Responses;

namespace KLabs.Business.Abstract
{
    public interface IReferenceService
    {
        DataResponse ReferenceList(DataSourceLoadOptions loadOptions);

        DataResponse ReferenceById(Guid id);

        DataResponse AddReference(Reference reference);

        DataResponse UpdateReference(Reference reference);

        DataResponse DeleteReference(Reference reference);
    }
}