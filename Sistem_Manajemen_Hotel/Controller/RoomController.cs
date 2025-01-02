using Sistem_Manajemen_Hotel.Model.Entity;
using Sistem_Manajemen_Hotel.Model.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sistem_Manajemen_Hotel.Model.Context;
using System.Data.SQLite;
using System.Diagnostics;
//using System.Windows.Forms;

namespace Sistem_Manajemen_Hotel.Controller
{
    public class RoomController
    {
        private RoomRepository _Roomrepository;
        public int Create(RoomEntity room)
        {
            int result = 0;

            Debug.WriteLine($"Controller - Create Room: RoomNumber = {room.RoomNumber}, TypeRoom = {room.TypeRoom}, Price = {room.Price}, Availability = {room.Availability}");

            using (DbContext context = new DbContext())
            {
                _Roomrepository = new RoomRepository(context);
                result = _Roomrepository.Create(room);
            }

            return result;
        }

        public List<RoomEntity> ReadByIdRoom(string idRoom)
        {
            // membuat objek collection
            List<RoomEntity> list = new List<RoomEntity>();
            using (DbContext context = new DbContext())
            {
                // membuat objek dari class repository
                _Roomrepository = new RoomRepository(context);
                list = _Roomrepository.ReadByIdRoom(idRoom);
            }
            return list;
        }
        public int Update(RoomEntity room)
        {
            int result = 0;

            using (DbContext context = new DbContext())
            {
                // membuat objek class repository
                _Roomrepository = new RoomRepository(context);
                result = _Roomrepository.Update(room);
            }

            return result;
        }

        public List<RoomEntity> readAllRoom()
        {
            List<RoomEntity> list = new List<RoomEntity>();
            using (DbContext context = new DbContext())
            {
                _Roomrepository = new RoomRepository(context);
                list = _Roomrepository.ReadAll();
            }
            return list;
        }
        public int Delete(RoomEntity DeleteRoom)
        {
            int result = 0;

            using (DbContext context = new DbContext())
            {
                // membuat objek class repository
                _Roomrepository = new RoomRepository(context);
                result = _Roomrepository.Delete(DeleteRoom);
            }

            return result;
        }
        public Dictionary<string, int> GetRoomCountsByType()
        {
            DbContext context = new DbContext();
            var roomRepository = new RoomRepository(context);
            return roomRepository.GetRoomCountsByType();
        }

    }
}
