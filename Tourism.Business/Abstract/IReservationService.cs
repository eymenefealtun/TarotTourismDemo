using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tourism.DataAccess.Abstract;

namespace Tourism.Entities.Concrete
{
    public interface IReservationService 
    {
        Reservation Get(int reservationId);
        Reservation Update(Reservation reservation);

    }
}
