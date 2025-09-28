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
    public class ParkingService : IParkingService
    {
        private readonly IGenericRepository<ParkingRecord> _recordRepository;
        private readonly IGenericRepository<Floor> _floorRepository;

        public ParkingService(IGenericRepository<ParkingRecord> recordRepository, IGenericRepository<Floor> floorRepository)
        {
            _recordRepository = recordRepository;
            _floorRepository = floorRepository;
        }
        public Task<decimal> CalculateFee(ParkingRecord record)
        {
            //Ücret hesaplama mantığı buraya yazılacak (saatlik,günlük ücretlendirme vb.)
            if (record.ExitTime.HasValue)
            {
                var duration = record.ExitTime.Value - record.EntryTime;
                var hours = (decimal)duration.TotalHours;
                //Örneğin saatlik 5tl
                return Task.FromResult(hours * 5);
            }
            return Task.FromResult(0m);
        }

        public async Task<ParkingRecord> ParkVehicleAsync(string vehiclePlate, int floorId)
        {
            var floor = await _floorRepository.GetByIdAsync(floorId);
            // Burada katın dolu olup olmadığı kontrolü yapılacak

            var parkingRecord = new ParkingRecord
            {
                VehiclePlate = vehiclePlate,
                FloorId = floorId,
                EntryTime = System.DateTime.Now
            };

            await _recordRepository.AddAsync(parkingRecord);
            return parkingRecord;
        }

        public async Task<ParkingRecord> UnparkVehicleAsync(string vehiclePlate)
        {
            // Plaka ile giriş kaydını bulma (çıkış yapmamış olanı)
            var record = (await _recordRepository.GetAllAsync())
                .FirstOrDefault(r => r.VehiclePlate == vehiclePlate && r.ExitTime == null);

            if (record == null) return null;

            record.ExitTime = System.DateTime.Now;
            record.Fee = await CalculateFee(record);

            _recordRepository.Update(record);

            return record;
        }
    }
}
