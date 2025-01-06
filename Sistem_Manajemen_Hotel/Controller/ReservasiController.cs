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
using System.Diagnostics;

namespace Sistem_Manajemen_Hotel.Controller
{
    public class ReservasiController
    {
        private ReservasiRepository _reservationRepository;

        public int Create(ReservasiEntity reservation)
        {
            int result = 0;

            if (reservation.id_reservasi <= 0)
            {
               MessageBox.Show("Id reservasi harus valid!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
               return 0;
            }
            if (string.IsNullOrEmpty(reservation.id_client.ToString()))
            {
               MessageBox.Show("Id client harus ada !", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
               return 0;
            }
            if (string.IsNullOrEmpty(reservation.id_room.ToString()))
            {
               MessageBox.Show("Tipe ruangan harus diisi!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
               return 0;
            }
            if (string.IsNullOrEmpty(reservation.masuk))
            {
               MessageBox.Show("Tanggal masuk harus diisi!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
               return 0;
            }
            if (string.IsNullOrEmpty(reservation.keluar))
            {
               MessageBox.Show("Tanggal keluar harus diisi!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
               return 0;
            }

            using (DbContext context = new DbContext())
            {
                _reservationRepository = new ReservasiRepository(context);
                result = _reservationRepository.Create(reservation);

                Debug.WriteLine($"controler data arrival --SQL Parameters: RoomNumber = {reservation.id_reservasi}, TypeRoom = {reservation.id_client}, Price = {reservation.masuk}, Availability = {reservation.keluar}");

            }

            return result;
        }

        public List<ReservasiEntity> ReadByIdReservasi(string IdReservasi)
        {
            List<ReservasiEntity> list = new List<ReservasiEntity>();

            using (DbContext context = new DbContext())
            {
                _reservationRepository = new ReservasiRepository(context);
                list = _reservationRepository.ReadByIdReservasi(IdReservasi);
            }

            return list;
        }

        public List<ReservasiEntity> ReadAll()
        {
            using (DbContext context = new DbContext())  // Pastikan DbContext diinisialisasi dengan benar
            {
                _reservationRepository = new ReservasiRepository(context);  // Mengirimkan DbContext
                return _reservationRepository.ReadAll();
            }
        }


        public int Update(ReservasiEntity reservation)
        {
            int result = 0;

            if (reservation.id_reservasi <= 0)
            {
                MessageBox.Show("Id reservasi harus valid untuk update!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            using (DbContext context = new DbContext())
            {
                _reservationRepository = new ReservasiRepository(context);
                result = _reservationRepository.Update(reservation);
            }

            return result;
        }

        public int Delete(ReservasiEntity reservation)
        {
            int result = 0;

            if (reservation == null || reservation.id_reservasi <= 0)
            {
                MessageBox.Show("Id reservasi harus valid untuk delete!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            using (DbContext context = new DbContext())
            {
                _reservationRepository = new ReservasiRepository(context);
                result = _reservationRepository.Delete(reservation.id_reservasi); // Kirim id_reservasi ke repository
            }

            return result;
        }

    }
}
