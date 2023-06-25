using Tourism.Entities.Abstract;


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
