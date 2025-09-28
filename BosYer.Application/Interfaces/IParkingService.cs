using BosYer.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BosYer.Application.Interfaces
{
    public interface IParkingService
    {
        Task<ParkingRecord> ParkVehicleAsync(string vehiclePlate, int floorId);
        Task<ParkingRecord> UnparkVehicleAsync(string vehiclePlate);
        Task<decimal> CalculateFee(ParkingRecord record);
    }
}
