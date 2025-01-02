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
//using System.Windows.Forms;

namespace Sistem_Manajemen_Hotel.Controller
{
    public class RoomController
    {
        private RoomRepository _Roomrepository;
        public int Create(RoomEntity room)
        {
            int result = 0;
            if (room.RoomNumber == 0)
            {
                MessageBox.Show("room number harus diisi !!!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
            if (room.Availability != "Yes" && room.Availability != "No")
            {
                MessageBox.Show("Pilih ketersediaan kamar (Yes/No).", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
            if (string.IsNullOrEmpty(room.Price.ToString()))
            {
                MessageBox.Show("type harga harus dipilih !!!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
            if (string.IsNullOrEmpty(room.TypeRoom))
            {
                MessageBox.Show("type kamar harus dipilih !!!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
            using (DbContext context = new DbContext())
            {
                // membuat objek class repository
                _Roomrepository = new RoomRepository(context);
                result = _Roomrepository.Create(room);
            }
            return result;
        }
        public List<RoomEntity> ReadByNama(string nama)
        {
            // membuat objek collection
            List<RoomEntity> list = new List<RoomEntity>();
            using (DbContext context = new DbContext())
            {
                // membuat objek dari class repository
                _Roomrepository = new RoomRepository(context);
                list = _Roomrepository.ReadByNama(nama);
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
    }
}
