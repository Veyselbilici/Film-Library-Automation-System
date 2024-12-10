using FinalProject.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Core.Services
{
    public interface IUserManager
    {
        bool RegisterUser(User user);
        User LoginUser(string userName, string password);
        bool UpdateUserInfo(string userTc, string nameSurname, string userName, string password, DateTime bornDate, int cinsiyetId);
        bool DeleteUser(string userTc);
        List<Gender> GetGenderList();
        bool SetUsersLastestLoginDate(User user);

    }
}
