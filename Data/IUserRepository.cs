using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TaksiDuragi.API.Models;

namespace TaksiDuragi.API.Data
{
    public interface IUserRepository : IAppRepository
    {
        Task<List<User>> GetUsers(int userID);
        Task<User> GetUser(Expression<Func<User, bool>> query);
        Task<List<UserDevice>> GetUserDevices(int userID);
        Task<UserDevice> GetUserDevice(string deviceSerialNumber);
    }
}
