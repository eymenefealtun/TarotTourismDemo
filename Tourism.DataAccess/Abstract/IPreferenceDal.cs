﻿using Tourism.Core.DataAccess.EntityFramework.Abstract;
using Tourism.Entities.Concrete;

namespace Tourism.DataAccess.Abstract
{
    public interface IPreferenceDal :IEntityRepository<Preference>
    {
    }
}
