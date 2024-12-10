namespace FinalProject.Core.Domain
{
    public class PremiumUser : User
    {
        public PremiumUser(string tC, string nameSurname, DateTime bornDate, Gender gender, bool isPremium, DateTime lastLoginDate,string password,string 
            username) : base(tC, nameSurname, bornDate, gender, isPremium, lastLoginDate,password, username)
        {

        }

        public PremiumUser()
        {

        }

        public override decimal CalculateMembershipFee()
        {
            return 100 * 125 / 100;
        }
    }
}
