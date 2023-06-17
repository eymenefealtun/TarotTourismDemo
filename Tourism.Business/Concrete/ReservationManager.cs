using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tourism.DataAccess.Concrete.EntityFramework;

namespace Tourism.Entities.Concrete
{
    public class ReservationManager : IReservationService
    {
        private IReservationDal _reservationDal;
        public ReservationManager(IReservationDal reservationDal)
        {
            _reservationDal = reservationDal;
        }

        public Reservation Get(int reservationId)
        {
            return _reservationDal.Get(x => x.Id == reservationId);
        }

        public Reservation Update(Reservation reservation)
        {
            return _reservationDal.Update(reservation);
        }
    }
}
