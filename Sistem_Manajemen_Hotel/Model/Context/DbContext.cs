using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;

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

            try 
            {
                string dbName = "database.db"; // Nama file database
                string appPath = AppDomain.CurrentDomain.BaseDirectory; // Lokasi folder aplikasi
                string dbPath = Path.Combine(appPath, dbName); // Gabungkan path aplikasi dengan nama database

                string connectionString = $"Data Source={dbPath}; FailIfMissing=True;";
                conn = new SQLiteConnection(connectionString);
                conn.Open();
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
