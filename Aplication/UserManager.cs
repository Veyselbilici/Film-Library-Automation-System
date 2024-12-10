using FinalProject.Core.Domain;
using FinalProject.Core.Services;
using FinalProject.Infstructure.Database.Mssql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace FinalProject.Aplication
{
    public class UserManager : IUserManager
    {
        private readonly FinalProjectDbContext db;
        public UserManager(FinalProjectDbContext _db)
        {
            db = _db;
        }
        public bool DeleteUser(string userTc)
        {
            var user = db.Users.First(x => x.TC == userTc);
            var watclists = db.WatchList.Where(x => x.UserId == userTc).ToList();
            var reviews = db.Reviews.Where(x => x.User.TC == userTc).ToList();
            db.RemoveRange(watclists);
            db.RemoveRange(reviews);

            db.Remove(user);
            db.SaveChanges();
            return true;
        }

        public List<Gender> GetGenderList()
        {
            return db.Genders.ToList();
        }

        public User LoginUser(string userName, string password)
        {
            return db.Users.FirstOrDefault(x => x.UserName == userName && x.Password == password);
        }

        public bool RegisterUser(User user)
        {
            var qDoesExists = db.Users.Where(x => x.UserName == user.UserName || x.TC == user.TC).Any();
            if (qDoesExists)
            {
                return false;
            }
            db.Users.Add(user);
            db.SaveChanges();
            return true;
        }

        public bool SetUsersLastestLoginDate(User user)
        {
            var dbuser = db.Users.First(x => x.TC == user.TC);
            dbuser.LastLoginDate = DateTime.Now;
            db.SaveChanges();
            return true;
        }

        public bool UpdateUserInfo(string userTc ,string nameSurname, string userName,string password,DateTime bornDate,int cinsiyetId)
        {
            var user = db.Users.Include(x=>x.Gender).First(x => x.TC == userTc);
            user.NameSurname = nameSurname;
            user.UserName = userName;
            user.Password = password;
            user.BornDate = bornDate;
            user.Gender = db.Genders.First(x => x.ID == cinsiyetId);
            db.SaveChanges();
            return true;
        }
    }
}
