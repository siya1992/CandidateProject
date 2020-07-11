using SiyaJuwarkarProject.Models.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SiyaJuwarkarProject.Repository.Account
{
    public interface IAccountRepository
    {
        bool Register(RegisterModel request);
         bool UserExists(string email, string password);
    }
    public class AccountRepository : IAccountRepository
    {
        public bool Register(RegisterModel registerRequest)
        {
            var query = string.Empty;
            RegisterModel response = new RegisterModel();


            using (var context = new TestEntities())
            {
                var candidate = new CANDIDATE()
                {
                    FIRSTNAME = registerRequest.FirstName,
                    LASTNAME = registerRequest.LastName,
                    EMAIL = registerRequest.Email,
                    MOBILE = registerRequest.Mobile,
                    CITY = registerRequest.City,
                    STATE = registerRequest.State,
                    COUNTRY = registerRequest.Country,
                    PASSWORD = registerRequest.Password
                    // IMAGELOCATION = registerRequest.

                };
                context.CANDIDATEs.Add(candidate);
                var result = context.SaveChanges();
                if (result > 0)
                    return true;
                else
                    return false;
            }
        }





        public bool UserExists(string email, string password)
        {

            var context = new TestEntities();
            var data = context.CANDIDATEs.Where(x=>x.EMAIL == email && x.PASSWORD == password).FirstOrDefault();

            if(data!=null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public List<RegisterModel> GetCandidates()
        {

            var context = new TestEntities();
            var list = new List<RegisterModel>();
            var data = context.CANDIDATEs.Include("WORKEXPERIENCE") ;
            foreach (var candidate in data)
            {
                var candidateDetails = new RegisterModel();
                candidateDetails.FirstName= candidate.FIRSTNAME;
                candidateDetails.LastName = candidate.LASTNAME;
                candidateDetails.Email = candidate.EMAIL;
                candidateDetails.WorkExperience =Convert.ToInt16(candidate.WORKEXPERIENCEs.Select(x => x.TODATE - x.FROMDATE));
                list.Add(candidateDetails);
                
            }
            return list;
            
        }
    }
}