using Sistem_Manajemen_Hotel.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sistem_Manajemen_Hotel.Model.Entity;
using Sistem_Manajemen_Hotel.Model.Repository;
using Sistem_Manajemen_Hotel.Model.Context;

namespace Sistem_Manajemen_Hotel.Controller
{
    public class ReservationController
    {
        private ReservationRepository _Reservationrepository;
        public int Create(ReservationEntity reservation)
        {
            int result = 0;
            if (reservation.id_reservation == null)
            {
                MessageBox.Show("Id reservai harus diisi !!!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
            if (string.IsNullOrEmpty(reservation.room_type))
            {
                MessageBox.Show("Tipe ruangan harus diisi !!!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
            if (string.IsNullOrEmpty(reservation.masuk))
            {
                MessageBox.Show("Tanggal masuk harus diisi !!!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
            if (string.IsNullOrEmpty(reservation.keluar))
            {
                MessageBox.Show("Tanggal keluar harus diisi !!!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
            using (DbContext context = new DbContext())
            {
                // membuat objek class repository
                _Reservationrepository = new ReservationRepository(context);
                result = _Reservationrepository.Create(reservation);
            }
            return result;
        }
        public List<ReservationEntity> ReadByNama(string roomtype)
        {
            // membuat objek collection
            List<ReservationEntity> list = new List<ReservationEntity>();
            using (DbContext context = new DbContext())
            {
                // membuat objek dari class repository
                _Reservationrepository = new ReservationRepository(context);
                list = _Reservationrepository.ReadByNama(roomtype);
            }
            return list;
        }
        public List<ReservationEntity> ReadAll()
        {
            // membuat objek collection
            List<ReservationEntity> list = new List<ReservationEntity>();
            using (DbContext context = new DbContext())
            {
                // membuat objek dari class repository
                _Reservationrepository = new ReservationRepository(context);
                list = _Reservationrepository.ReadAll();
            }
            return list;
        }
        public int Update(ReservationEntity reservation)
        {
            int result = 0;

            using (DbContext context = new DbContext())
            {
                // membuat objek class repository
                _Reservationrepository = new ReservationRepository(context);
                result = _Reservationrepository.Update(reservation);
            }
            return result;
        }
        public int Delete(ReservationEntity reservasi)
        {
            int result = 0;

            using (DbContext context = new DbContext())
            {
                // membuat objek class repository
                _Reservationrepository = new ReservationRepository(context);
                result = _Reservationrepository.Delete(reservasi);
            }

            return result;
        }
    }
}
