﻿using Tourism.Core.DataAccess.EntityFramework.Abstract;
using Tourism.Entities.Concrete;

namespace Tourism.Entities.Abstract
{
    public interface IReservationDal : IEntityRepository<Reservation>
    {
    }       
}
