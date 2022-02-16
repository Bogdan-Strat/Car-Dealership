using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Managers
{
    public interface IAuthentificationManager
    {
        Task SignUp(RegisterModel registerModel);

        Task<TokensModel> Login(LoginModel loginModel);

    }
}
