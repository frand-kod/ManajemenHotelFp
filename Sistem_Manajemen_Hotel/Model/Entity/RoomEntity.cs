using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistem_Manajemen_Hotel.Model.Entity
{
    public class RoomEntity
    {
        public int IdRoom { get; set; }
        public int RoomNumber { get; set; }
        public string TypeRoom { get; set; }
        public int Price { get; set; }
        public string Availability { get; set; }
    }
}
