using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistem_Manajemen_Hotel.Model.Entity
{
    public class ReservasiEntity
    {
        public int id_reservasi { get; set; }
        public int id_client { get; set; }
        public int id_room { get; set; }
        public string masuk { get; set; }
        public string keluar { get; set; }
    }
}
