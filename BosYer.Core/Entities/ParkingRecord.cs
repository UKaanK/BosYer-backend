using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BosYer.Core.Entities
{
    public class ParkingRecord
    {
        public int Id { get; set; }
        public string VehiclePlate { get; set; }
        public DateTime EntryTime { get; set; }
        public DateTime? ExitTime { get; set; }
        public decimal? Fee { get; set; }
        public int FloorId { get; set; }
        public Floor Floor { get; set; }
    }
}
