using ProductManagementDBEntity.Models;
using ProductManagementDBEntity.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserManagement.Helper
{
    public interface IUserManagementHelper
    {
        Task<UserDetails> UserLogin(string userName, string password);

        Task<bool> UserRegister(UserDetails userDetails);

        Task<bool> UpdateProfile(UserDetails userDetails);

        Task<UserDetails> ViewProfile(string userId);

    }

    public class UserManagementHelper : IUserManagementHelper
    {

        private readonly IUserRepository _iUserRepository;

        public UserManagementHelper(IUserRepository iUserRepository)
        {
            _iUserRepository = iUserRepository;
        }

        public async Task<bool> UserRegister(UserDetails userDetails)
        {
            try
            {
                bool user = await _iUserRepository.UserRegister(userDetails);
                return user;
            }
            catch
            {
                throw;
            }
        }

        public async Task<UserDetails> UserLogin(string userName, string password)
        {

            try
            {
                UserDetails userDetails = await _iUserRepository.UserLogin(userName, password);
                if (userDetails != null)
                {
                    return userDetails;
                }
                else
                    return null;
            }
            catch
            {
                throw;
            }
            //return await _iUserRepository.UserLogin(userName, password);
        }

        public async Task<bool> UpdateProfile(UserDetails userDetails)
        {


            try
            {
                bool user = await _iUserRepository.UpdateProfile(userDetails);
                if (user == true)
                {
                    return true;
                }
                else
                    return false;
            }
            catch
            {
                throw;
            }

        }


        public async Task<UserDetails> ViewProfile(string userId)
        {

            try
            {
                UserDetails userDetails = await _iUserRepository.ViewProfile(userId);
                if (userDetails != null)
                {
                    return userDetails;
                }
                else
                    return null;
            }
            catch
            {
                throw;
            }

        }
    }
}
