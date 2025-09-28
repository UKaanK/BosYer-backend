using BosYer.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BosYer.Application.Interfaces
{
    public interface IParkingLotService
    {
        Task<IEnumerable<ParkingLot>> GetParkingLotsByOwnerIdAsync(int ownerId);
        Task<ParkingLot> GetParkingLowWithFloorAsync(int parkingLotId);
        Task<ParkingLot> CreateParkingLotAsync(ParkingLot parkingLot);
        Task<bool> UpdateParkingLotAsync(ParkingLot parkingLot);
        Task<bool> DeleteParkingLotAsync(int parkingLotId);

        Task<Floor> CreateFloorAsync(Floor floor);
        Task<bool> UpdateFloorAsync(Floor floor);
        Task<bool> DeleteFloorAsync(int floorId);
    }
}
