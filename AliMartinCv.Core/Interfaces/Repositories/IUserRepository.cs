using AliMartinCv.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AliMartinCv.Core.Interfaces.Repositories
{
    public interface IUserRepository
    {
        //CRUD : Create,Read,Upadte,Delete
        Task<bool> CreateAsync(User user);
        Task<bool> UpdateAsync(User user);
        Task<bool> DeleteAsync(User user);
        Task<User> GetUserAsync(int userId);
        Task<IEnumerable<User>> GetUsersAsync();
        Task<User> GetByEmailAsync(string email);




    }
}
