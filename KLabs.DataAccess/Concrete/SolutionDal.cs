using System;
using System.Collections.Generic;
using System.Text;
using KLabs.Core.DataAccess.Abstract;
using KLabs.Core.DataAccess.Concrete;
using KLabs.DataAccess.Abstract;
using KLabs.DataAccess.Core;
using KLabs.Entities.Concrete;

namespace KLabs.DataAccess.Concrete
{
    public class SolutionDal : EntityRepositoryBase<Solution, KLabsContext>, ISolutionDal
    {
    }
}
