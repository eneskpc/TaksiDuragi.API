using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TaksiDuragi.API.Models;

namespace TaksiDuragi.API.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly TaksiVarmiContext _context;
        private readonly IAppRepository _appRepo;
        public UserRepository(TaksiVarmiContext context, IAppRepository appRepo)
        {
            _context = context;
            _appRepo = appRepo;
        }
        public async Task<T> Add<T>(T entity) where T : class
        {
            return await _appRepo.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _appRepo.Delete(entity);
        }

        public async Task<User> GetUser(Expression<Func<User, bool>> query)
        {
            var user = await _context.Users.FirstOrDefaultAsync(query);

            if (user == null)
            {
                return null;
            }
            return user;
        }

        public async Task<UserDevice> GetUserDevice(string deviceSerialNumber)
        {
            var device = await _context.UserDevices.FirstOrDefaultAsync(c => c.IsDeleted == false && c.SerialNumber == deviceSerialNumber);

            if (device == null)
            {
                return null;
            }
            return device;
        }

        public async Task<List<UserDevice>> GetUserDevices(int userID)
        {
            var devices = await _context.UserDevices.Where(c => c.IsDeleted == false && c.UserId == userID).ToListAsync();

            if (devices == null || devices.Count == 0)
            {
                return null;
            }
            return devices;
        }

        public async Task<List<User>> GetUsers(int userID)
        {
            var users = await _context.Users.Where(c => c.IsDeleted == false && c.Id == userID).ToListAsync();

            if (users == null || users.Count == 0)
            {
                return null;
            }
            return users;
        }
    }
}
