using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistem_Manajemen_Hotel.Model.Entity
{
    public class ReservationEntity
    {
        public int id_reservation { get; set; }
        public string room_type { get; set; }
        public string masuk { get; set; }
        public string keluar { get; set; }
    }
}
