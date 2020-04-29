using ProductManagementDBEntity.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagementDBEntity.Repositories
{
    public interface IUserRepository
    {
        Task<UserDetails> UserLogin(string userName, string password);

        Task<bool> UserRegister(UserDetails userDetails);

        Task<bool> UpdateProfile(UserDetails userDetails);

        Task<UserDetails> ViewProfile(string userId);
    }
}
