using System.Collections.Generic;
using System.Threading.Tasks;
using Client.Models;

namespace Client.Data
{
    public interface IAdultData
    {
        Task<IList<Adult>> GetAdultsAsync();
        Task AddAdultAsync(Adult adult);
        Task UpdateAdultAsync(Adult adult);
        Task DeleteAdultsAsync(Adult adult);
        Adult GetId(int id);
    }
}