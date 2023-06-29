
namespace Tourism.Entities.Concrete
{
    public interface IReservationService
    {
        Reservation Get(int reservationId);
        Reservation Update(Reservation reservation);
        List<Reservation> GetAll();
        List<Reservation> GetByReservattionCode(string reservationCode);

    }
}
