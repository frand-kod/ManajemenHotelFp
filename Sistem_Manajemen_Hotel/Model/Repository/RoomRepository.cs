using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sistem_Manajemen_Hotel.Model.Context;
using Sistem_Manajemen_Hotel.Model.Entity;
using Sistem_Manajemen_Hotel.Model.Repository;

namespace Sistem_Manajemen_Hotel.Model.Repository
{
    public class RoomRepository
    {
        private SQLiteConnection _conn;
        public RoomRepository(DbContext context)
        {
            _conn = context.Conn;
            
        }
        public int Create(RoomEntity room)
        {
            int result = 0;
            //string sql = @"INSERT INTO room (room_number, availability, type_room,price) VALUES (@room_number, @availability, @type_room,@price)";

            string sql = @"INSERT INTO room (room_number, availability, type_room, harga) 
               VALUES (@room_number, @availability, @type_room, @harga);";
            //string pragmaSql = "PRAGMA integrity_check;";


            using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
            {
                Debug.WriteLine($"dari repo create --roomNumber: {room.RoomNumber}, availability: {room.Availability}, typeRoom: {room.TypeRoom}, price: {room.Price}");

                cmd.Parameters.AddWithValue("@room_number", room.RoomNumber);
                cmd.Parameters.AddWithValue("@availability", room.Availability);
                cmd.Parameters.AddWithValue("@type_room", room.TypeRoom);
                cmd.Parameters.AddWithValue("@harga", room.Price);


                try
                {
                    // jalankan perintah INSERT dan tampung hasilnya ke dalam variabel result
                    result = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {


                    System.Diagnostics.Debug.Print("Create error: {0}", ex.Message);
                    PragmaChecker();
                }
                return result;
            }
        }



            private int PragmaChecker() {
            using (var connection = new SQLiteConnection(_conn))
            {
                connection.Open();
                string checkTableQuery = "SELECT name FROM sqlite_master WHERE type='table' AND name='rooms';";
                using (var command = new SQLiteCommand(checkTableQuery, connection))
                {
                    var tableName = command.ExecuteScalar();
                    if (tableName == null)
                    {
                        Debug.WriteLine("Table 'rooms' does not exist in the database.");
                        return 1;
                    }
                    else
                    {
                        Debug.WriteLine("Table 'rooms' found.");
                        return 0;
                    }
                }
            }


        }
        public List<RoomEntity> ReadAll()
        {
            List<RoomEntity> list = new List<RoomEntity>();
            try
            {

                string sql = @"SELECT * FROM room";

                using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
                {
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            RoomEntity room = new RoomEntity();
                            room.IdRoom = Convert.ToInt32(reader["id_room"]);
                            room.RoomNumber = Convert.ToInt32(reader["room_number"]);
                            room.Availability = reader["availability"].ToString();
                            room.TypeRoom = reader["type_room"].ToString();
                            room.Price = Convert.ToInt32(reader["price"]);

                            list.Add(room);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print("ReadAll error: {0}", ex.Message);
            }
            return list;
        }
        public List<RoomEntity> ReadByNama(string nama)
        {
            List<RoomEntity> list = new List<RoomEntity>();
            try
            {

                string sql = @"SELECT id_room, room_number, availability, type_room FROM room WHERE type_room LIKE @type_room";

                using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
                {
                    cmd.Parameters.AddWithValue("@type_room", string.Format("%{0}%", nama));

                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            while (reader.Read())
                            {
                                RoomEntity room = new RoomEntity();
                                room.IdRoom = Convert.ToInt32(reader["id_room"]);
                                room.RoomNumber = Convert.ToInt32(reader["room_number"]);
                                room.Availability = reader["Deskripsi"].ToString();
                                room.TypeRoom = reader["Harga"].ToString();

                                list.Add(room);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print("ReadByNama error: {0}", ex.Message);
            }
            return list;
        }
        public int Update(RoomEntity room)
        {
            int result = 0;
            string sql = @"UPDATE Barang SET NamaBarang = @nama, Deskripsi = @deskripsi, Harga = @harga, Stok = @stok WHERE BarangID = @id";

            using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
            {
                cmd.Parameters.AddWithValue("@id_room", room.IdRoom);
                cmd.Parameters.AddWithValue("@room_number", room.RoomNumber);
                cmd.Parameters.AddWithValue("@availability", room.Availability);
                cmd.Parameters.AddWithValue("@type_room", room.TypeRoom);

                try
                {
                    result = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.Print("Update error: {0}", ex.Message);
                }
            }
            return result;
        }
        public int Delete(RoomEntity room)
        {
            int result = 0;
            string sql = @"DELETE FROM Barang WHERE BarangID = @id";

            using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
            {
                cmd.Parameters.AddWithValue("@id", room.IdRoom);

                try
                {
                    result = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.Print("Delete error: {0}", ex.Message);
                }
            }

            return result; // Tambahkan kembalikan nilai result di sini
        }
    }
}
