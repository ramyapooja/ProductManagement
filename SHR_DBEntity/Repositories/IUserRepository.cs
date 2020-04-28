using ProductManagementDBEntity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductManagementDBEntity.Repositories
{
    public interface IUserRepository
    {
        UserDetails UserLogin(string uname, string pwd);

        void UserRegister(UserDetails userobj);

        void UpdateProfile(UserDetails bobj);

        UserDetails ViewProfile(string bid);
    }
}
