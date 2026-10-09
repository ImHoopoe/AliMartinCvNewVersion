using AliMartinCv.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AliMartinCv.Core.Interfaces.Repositories
{
    public interface IUserRepository
    {
        //CRUD : Create,Read,Upadte,Delete
        Task<bool> Create(User user);
        Task<bool> Update(User user);
        Task<bool> Delete(User user);
        Task<User> GetUser(int userId);
        Task<IEnumerable<User>> GetUsers();
        Task<User> GetByEmail(string email);




    }
}
