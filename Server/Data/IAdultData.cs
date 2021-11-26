using System.Collections.Generic;
using System.Threading.Tasks;
using Server.Models;

namespace Server.Data
{
    public interface IAdultData
    {
        Task<IList<Adult>> GetAdults();
        Task<Adult> AddAdult(Adult adult);
        Task<Adult> UpdateAdult(Adult adult);
        Task DeleteAdult(int adultId);
        Adult GetId(int id);
    }
}