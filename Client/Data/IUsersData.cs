using Client.Models;

namespace Client.Data
{
    public interface IUsersData
    {
        Users ValidateUsers(string userName, string Password);
    }
}