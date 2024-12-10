using FinalProject.Core.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Core.Domain
{
    public abstract class User
    {
        public string TC
        {
            get; set;
        }

        public string NameSurname { get; set; }

        public DateTime BornDate { get; set; }

        public Gender Gender { get; set; }

        public bool IsPremium { get; }
        public string UserName { get; set; }
        public string Password { get; set; }

        // to acomplish polymorphic behaviour
        public abstract decimal CalculateMembershipFee();

        public User(string tC, string nameSurname, DateTime bornDate, Gender Gender, bool IsPremium, DateTime lastLoginDate, string password, string username)
        {
            TC = tC;
            this.UserName = username;
            NameSurname = nameSurname;
            BornDate = bornDate;
            this.Gender = Gender;
            this.IsPremium = IsPremium;
            this.LastLoginDate = lastLoginDate;
            this.Password = password;
        }
        public DateTime LastLoginDate { get; set; }

        // this is beacouse of ef core couldn't figure out how to solve this issue
        public User()
        {

        }
    }
}
