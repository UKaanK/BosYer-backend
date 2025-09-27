using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BosYer.Core.Entities
{
    public class Floor
    {
        public int Id { get; set; }
        public string FloorName { get; set; }
        public int FloorNumber { get; set; }
        public int Capacity { get; set; }

        public int ParkingLotId { get; set; }
        public ParkingLot ParkingLot { get; set; }
        public ICollection<ParkingRecord> ParkingRecords { get; set; }
    }
}
