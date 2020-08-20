using System;
using DevExtreme.AspNet.Mvc;
using KLabs.Entities.Concrete;
using KLabs.Entities.Responses;

namespace KLabs.Business.Abstract
{
    public interface ISolutionService
    {
        DataResponse SolutionList(DataSourceLoadOptions loadOptions);

        DataResponse SolutionById(Guid id);

        DataResponse AddSolution(Solution solution);

        DataResponse UpdateSolution(Solution solution);

        DataResponse DeleteSolution(Solution solution);

        DataResponse StaticSolutions();

        DataResponse HomePageSolutions(int page);

        DataResponse SolutionDetail(Guid id);
    }
}