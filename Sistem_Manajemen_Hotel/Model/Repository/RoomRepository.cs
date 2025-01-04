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
            string sql = @"
                   INSERT INTO room (room_number, type_room, harga, availability)
                            VALUES (@room_number, @type_room, @price, @availability)";

            using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
            {
                // Menambahkan parameter
                cmd.Parameters.AddWithValue("@room_number", room.RoomNumber);
                cmd.Parameters.AddWithValue("@type_room", room.TypeRoom);
                cmd.Parameters.AddWithValue("@price", room.Price);
                cmd.Parameters.AddWithValue("@availability", room.Availability);

                try
                {
                    result = cmd.ExecuteNonQuery();
                    Debug.WriteLine($"Rows inserted: {result}");
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"Error inserting room: {ex.Message}");
                    Debug.WriteLine($"SQL Parameters: RoomNumber = {room.RoomNumber}, TypeRoom = {room.TypeRoom}, Price = {room.Price}, Availability = {room.Availability}");
                }
            }
            return result;
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
                            room.Price = Convert.ToInt32(reader["harga"]);

                            list.Add(room);
                            //Debug.WriteLine($"dari repo readall --roomNumber: {room.RoomNumber}, availability: {room.Availability}, typeRoom: {room.TypeRoom}, price: {room.Price}");
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
        public List<RoomEntity> ReadByIdRoom(string idRoom)
        {
            List<RoomEntity> list = new List<RoomEntity>();
            try
            {
                string sql = @"SELECT id_room, room_number, availability, type_room FROM room WHERE id_room LIKE @id_room";

                using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
                {
                    cmd.Parameters.AddWithValue("@id_room", string.Format("%{0}%", idRoom));

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

            string sql = @"UPDATE room 
                   SET room_number = @room_number, 
                       availability = @availability, 
                       type_room = @type_room, 
                       harga = @harga 
                   WHERE id_room = @id_room";

            using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
            {
                cmd.Parameters.AddWithValue("@id_room", room.IdRoom);
                cmd.Parameters.AddWithValue("@room_number", room.RoomNumber);
                cmd.Parameters.AddWithValue("@availability", room.Availability);
                cmd.Parameters.AddWithValue("@type_room", room.TypeRoom);
                cmd.Parameters.AddWithValue("@harga", room.Price);

                try
                {
                    result = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.Print("Update error: {0}", ex.Message);
                    Debug.WriteLine($"dari repo Update --roomNumber: {room.RoomNumber}, availability: {room.Availability}, typeRoom: {room.TypeRoom}, price: {room.Price}");

                }
            }
            return result;
        }
        public int Delete(RoomEntity room)
        {
            int result = 0;
            string sql = @"DELETE FROM room 
                           WHERE id_room = @id_room";

            using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
            {
                cmd.Parameters.AddWithValue("@id_room", room.IdRoom);

                try
                {
                    result = cmd.ExecuteNonQuery();
                    Debug.WriteLine($"dari repo Delete --room id :{room.IdRoom}, roomNumber: {room.RoomNumber}, availability: {room.Availability}, typeRoom: {room.TypeRoom}, price: {room.Price}");

                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.Print("Delete error: {0}", ex.Message);
                }
            }

            return result; // Tambahkan kembalikan nilai result di sini
        }

        public Dictionary<string, int> GetRoomCountsByType()
        {
            Dictionary<string, int> roomCounts = new Dictionary<string, int>();

            string sql = @"
                    SELECT type_room, COUNT(*) AS jumlah_kamar
                    FROM room
                    GROUP BY type_room";

            using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
            {
                try
                {
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string typeRoom = reader["type_room"].ToString();
                            int count = Convert.ToInt32(reader["jumlah_kamar"]);
                            roomCounts[typeRoom] = count;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"Error fetching room counts: {ex.Message}");
                }
            }
            return roomCounts;
        }

    }
}
