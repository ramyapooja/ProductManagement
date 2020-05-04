using ProductManagementDBEntity.Models;
using SHR_Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagementDBEntity.Repositories
{
    public interface IUserRepository
    {
        Task<UserDetails> UserLogin(UserLogin user);

        Task<bool> UserRegister(UserDetails userDetails);

        Task<bool> UpdateProfile(UserDetails userDetails);

        Task<UserDetails> ViewProfile(int userId);
    }
}
