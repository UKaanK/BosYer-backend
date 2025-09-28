using BosYer.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BosYer.Application.Interfaces
{
    public interface IAuthService
    {
        Task<ParkingOwner> RegisterOwnerAsync(ParkingOwner parkingOwner, string password);
        Task<ParkingOwner> LoginOwnerAsync(string email, string password);
    }
}
