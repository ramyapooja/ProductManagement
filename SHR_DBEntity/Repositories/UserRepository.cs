using Microsoft.EntityFrameworkCore;
using ProductManagementDBEntity.Models;
using ProductManagementDBEntity.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserManagement.Helper
{
    public class UserRepository : IUserRepository

    {


        private readonly ProductDBContext _productDBContext;
        public UserRepository(ProductDBContext productDBContext)
        {
            _productDBContext = productDBContext;
        }


        public async Task<UserDetails> UserLogin(string userName, string password)
        {
            try
            {
                return await _productDBContext.UserDetails.SingleOrDefaultAsync(e => e.Username == userName && e.Password == password);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<bool> UserRegister(UserDetails userDetails)
        {
            try
            {
                _productDBContext.UserDetails.Add(userDetails);
                var productId = await _productDBContext.SaveChangesAsync();
                if (productId > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception e)
            {
                // To Do Log
                throw;
            }
        }

        public async Task<bool> UpdateProfile(UserDetails userDetails)
        {
            try
            {
                _productDBContext.UserDetails.Add(userDetails);
                var productId = await _productDBContext.SaveChangesAsync();
                if (productId > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception e)
            {
                // To Do Log
                throw;
            }
        }

        public async Task<UserDetails> ViewProfile(string userId)
        {
            try
            {
                return await _productDBContext.UserDetails.FindAsync(userId);
            }
            catch (Exception e)
            {
                throw;
            }

        }



    }
}
