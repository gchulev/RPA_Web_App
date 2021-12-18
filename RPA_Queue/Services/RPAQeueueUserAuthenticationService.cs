using RPA_Queue.Models;
using RPA_Queue.ViewModels;
using RPA_Queue.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Threading.Tasks;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;
using System.Net;
using RPA_Queue.Data;

namespace RPA_Queue.Services
{
    public class RPAQeueueUserAuthenticationService : IRPAQueueUserAuthenticationService
    {

        public async Task<bool> CheckIfUserCanAuthenticateAsync(string userName, string password)
        {
            bool foundInAD = false;
            await Task.Run(() =>
            {
                const string Domain = "ads.dlh.de";

                using (var context = new PrincipalContext(ContextType.Domain, Domain))
                {
                    // string pass = new NetworkCredential("", password).Password;
                    foundInAD = context.ValidateCredentials(userName, password);
                }
            });

            return foundInAD;
        }

        public ApplicationUserViewModel MapModels(ApplicationUser userModel)
        {
            ApplicationUserViewModel userViewModel = new()
            {
                UserName = userModel.UserName,
            };

            return userViewModel;
        }

        public ApplicationUser MapModels(ApplicationUserViewModel userViewModel)
        {
            ApplicationUser userModel = new()
            {
                UserName = userViewModel.UserName,
            };

            return userModel;
        }
    }

}
