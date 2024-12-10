using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Core.Domain
{
    public class StandartUser : User
    {
        public StandartUser(string tC, string nameSurname, DateTime bornDate, Gender gender, bool isPremium,DateTime lastLoginDate,string password, string username) : base(tC, nameSurname, bornDate, gender, isPremium,lastLoginDate, password,username)
        {
        }

        public StandartUser()
        {
           
        }

        public override decimal CalculateMembershipFee()
        {
            return 100;
        }
    }
}
