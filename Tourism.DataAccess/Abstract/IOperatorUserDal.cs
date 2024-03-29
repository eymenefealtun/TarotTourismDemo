﻿using Tourism.Core.DataAccess.EntityFramework.Abstract;
using Tourism.Entities.Concrete;

namespace Tourism.Entities.Abstract
{
    public interface IOperatorUserDal : IEntityRepository<OperatorUser>
    {
        OperatorUser GetByUsernameAndPassword(string username, string password);
        OperatorUser GetByUsernameSqlRaw(string username);

    }
}
