﻿using Tourism.Core.DataAccess.EntityFramework.Concrete;
using Tourism.DataAccess.Concrete.EntityFramework;
using Tourism.Entities.Abstract;

namespace Tourism.Entities.Concrete
{
    public class EfOperatorUserDal : EfEntityRepositoryBase<OperatorUser, AppDbContext>, IOperatorUserDal
    {
    }
}
