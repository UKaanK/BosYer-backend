using BosYer.Application.Interfaces;
using BosYer.Application.Interfaces.Data;
using BosYer.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BosYer.Application.Services
{
    public class ParkingLotService : IParkingLotService
    {
        //Bu servis, veri tabanı işlemleri için Infrastructure katmanındaki reposityle kullanacak
        private readonly IGenericRepository<ParkingLot> _parkingLotRepository;
        private readonly IGenericRepository<Floor> _floorRepository;

        public ParkingLotService(IGenericRepository<ParkingLot> parkingRepository, IGenericRepository<Floor> floorRepository)
        {
            _parkingLotRepository = parkingRepository;
            _floorRepository = floorRepository;
        }

        public async Task<Floor> CreateFloorAsync(Floor floor)
        {
            await _floorRepository.AddAsync(floor);
            return floor;
        }

        public async Task<ParkingLot> CreateParkingLotAsync(ParkingLot parkingLot)
        {
            await _parkingLotRepository.AddAsync(parkingLot);
            //SaveChanges API katmanında olacak
            return parkingLot;
        }

        public async Task<bool> DeleteFloorAsync(int floorId)
        {
            var floor = await _floorRepository.GetByIdAsync(floorId);
            if (floor==null)
            {
                return false;
            }
            _floorRepository.Delete(floor);
            return true;
        }

        public async Task<bool> DeleteParkingLotAsync(int parkingLotId)
        {
            var parkingLot = await _parkingLotRepository.GetByIdAsync(parkingLotId);
            if (parkingLot==null)
            {
                return false;
            }
            _parkingLotRepository.Delete(parkingLot);
            return true;
        }

        public async Task<IEnumerable<ParkingLot>> GetParkingLotsByOwnerIdAsync(int ownerId)
        {
            //LINQ ile otopark sahibinin otoparklarını getirme mantığı olacak
            return await _parkingLotRepository.GetAllAsync();
        }

        public async Task<ParkingLot> GetParkingLowWithFloorAsync(int parkingLotId)
        {
            //Include metodu ile otoparkın katlarını getirme mantığı
            return await _parkingLotRepository.GetByIdAsync(parkingLotId);
        }

        public async Task<bool> UpdateFloorAsync(Floor floor)
        {
            _floorRepository.Update(floor);
            return true;
        }

        public async Task<bool> UpdateParkingLotAsync(ParkingLot parkingLot)
        {
            _parkingLotRepository.Update(parkingLot);
            return true;
        }
    }
}
    ;