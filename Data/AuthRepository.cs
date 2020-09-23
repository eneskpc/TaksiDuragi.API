using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TaksiDuragi.API.Models;

namespace TaksiDuragi.API.Data
{
    public class AuthRepository : IAuthRepository
    {
        private readonly TaksiVarmiContext _context;

        public AuthRepository(TaksiVarmiContext context)
        {
            _context = context;
        }

        public async Task<User> Register(User user, string password)
        {
            CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return user;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using var hmac = new System.Security.Cryptography.HMACSHA512();

            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        }

        public async Task<User> Login(string userName, string password)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Email == userName);
            if (user == null)
            {
                return null;
            }

            if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
            {
                return null;
            }

            return user;
        }

        private bool VerifyPasswordHash(string password, byte[] userPasswordHash, byte[] userPasswordSalt)
        {
            using var hmac = new System.Security.Cryptography.HMACSHA512(userPasswordSalt);

            var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            for (int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != userPasswordHash[i])
                {
                    return false;
                }
            }

            return true;
        }

        public async Task<bool> UserExists(string userName)
        {
            if (await _context.Users.AnyAsync(x => x.Email == userName))
            {
                return true;
            }
            return false;
        }
    }
}
