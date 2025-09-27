using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BosYer.Core.Entities
{
    public class ParkingLot
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int TotalCapacity { get; set; }
        public bool IsActivate { get; set; }
        public int ParkingOwnerId { get; set; }
        public ParkingOwner ParkingOwner { get; set; }
        public ICollection<Floor> Floors { get; set; }
    }
}
