using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tourism.DataAccess.Concrete.EntityFramework;

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
            return _roomDal.GetAllWithFilter(x => x.ReservationId == reservationId);
        }
    }
}
