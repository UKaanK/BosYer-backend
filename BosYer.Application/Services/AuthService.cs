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
    public class AuthService : IAuthService
    {
        private readonly IGenericRepository<ParkingOwner> _ownerRepository;
        public AuthService(IGenericRepository<ParkingOwner> ownerRepository)
        {
            _ownerRepository = ownerRepository;           
        }
        public async Task<ParkingOwner> LoginOwnerAsync(string email, string password)
        {
            //Veritabanından kullanıcıyı getirme ve şifre doğrulaması burada yapılacak
            //var owner = await _ownerRepository.GetByEmailAsync(email);
            //if (owner!=null && VerifyPassword(password,owner.PasswordHash))
            //{
            //  return owner;
            //
            return null;
        }

        public async Task<ParkingOwner> RegisterOwnerAsync(ParkingOwner parkingOwner, string password)
        {
            //Şifreyi hashleme işlemi burada 


            await _ownerRepository.AddAsync(parkingOwner);
            return parkingOwner;
        }
    }
}
