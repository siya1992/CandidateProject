using SiyaJuwarkarProject.Models.Account;
using SiyaJuwarkarProject.Repository.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SiyaJuwarkarProject.Manager.Account
{
    public interface IAccountManager
    {
        bool Register(RegisterModel request);
        bool UserExists(string email, string password);
    }
    public class AccountManager : IAccountManager
    {
        private readonly IAccountRepository _IAccountRepository;
        public bool Register(RegisterModel registerRequest)
        {
            var response = false;
            try
            {
                if (response != null)
                {
                    AccountRepository accRepo = new AccountRepository();
                    response = accRepo.Register(registerRequest);
                }
            }
            catch (Exception ex)
            {

            }

            return response;
        }


        public bool UserExists(string email, string password)
        {
            var repository = new AccountRepository();
            return repository.UserExists(email, password);
        }

        public List<RegisterModel> GetCandidates()
        {
            try
            {
               
                    AccountRepository accRepo = new AccountRepository();

                    return accRepo.GetCandidates();
                
            }
            catch (Exception ex)
            {

            }

            return response;
        }
    }
}