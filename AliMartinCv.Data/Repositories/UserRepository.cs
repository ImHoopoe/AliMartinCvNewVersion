using AliMartinCv.Core.Entities;
using AliMartinCv.Core.Interfaces.Repositories;
using AliMartinCv.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AliMartinCv.Data.Repositories
{

    public class UserRepository : IUserRepository
    {
        private readonly AliMartinCvContext _context;
        public UserRepository(AliMartinCvContext context)
        {
            _context = context;
        }


        public async Task<bool> Create(User user)
        {
            try
            {
                await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }

        public async Task<bool> Delete(User user)
        {
            try
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }

        public async Task<User> GetByEmail(string email)
        {
            //AMirHoSse in@g mail.C O M => AMirHoSsein@gmail.COM => amirhossein@gmail.com
            return await _context.Users.SingleOrDefaultAsync(u => u.Email.ToLower().Trim() == email.ToLower().Trim());
        }

        public async Task<User> GetUser(int userId)
        {
            return await _context.Users.FindAsync(userId);
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<bool> Update(User user)
        {
            try
            {
                _context.Users.Update(user);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }
    }
}
