using Tourism.Entities.Abstract;


namespace Tourism.Entities.Concrete
{
    public class RoomManager : IRoomService
    {
        private IRoomDal _roomDal;
        public RoomManager(IRoomDal roomDal)
        {
            _roomDal = roomDal;             
        }

        public List<Room> GetByReservationId(int reservationId)
        {
            return _roomDal.GetAll(x => x.ReservationId == reservationId);
        }
    }
}
