using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace Sistem_Manajemen_Hotel.Model.Context
{
    public class DbContext : IDisposable
    {
        // deklarasi private variabel / field
        private SQLiteConnection _conn;
        public SQLiteConnection Conn
        {
            get { return _conn ?? (_conn = GetOpenConnection()); }
        }
        private SQLiteConnection GetOpenConnection()
        {
            SQLiteConnection conn = null; // deklarasi objek connection
            try // penggunaan blok try-catch untuk penanganan error
            {
                // atur ulang lokasi database yang disesuaikan dengan
                // lokasi database perpustakaan Anda
                string dbName = @"D:\SEMESTER 3\Pemrograman Lanjut\Final\Sistem_Manajemen_Hotel\Sistem_Manajemen_Hotel\bin\Debug\database.db";
                // deklarasi variabel connectionString, ref: https://www.connectionstrings.com/
                string connectionString = string.Format("Data Source ={0}; FailIfMissing = True", dbName);
                conn = new SQLiteConnection(connectionString); // buat objek connection
                conn.Open(); // buka koneksi ke database
            }
            // jika terjadi error di blok try, akan ditangani langsung oleh blok catch 
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print("Open Connection Error: {0}",
               ex.Message);
            }
            return conn;
        }
        public void Dispose()
        {
            if (_conn != null)
            {
                try
                {
                    if (_conn.State != ConnectionState.Closed) _conn.Close();
                }
                finally
                {
                    _conn.Dispose();
                }
            }
            GC.SuppressFinalize(this);
        }
    }
}
