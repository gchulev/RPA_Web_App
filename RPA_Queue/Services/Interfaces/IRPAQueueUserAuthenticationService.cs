using RPA_Queue.Models;
using RPA_Queue.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Threading.Tasks;

namespace RPA_Queue.Services.Interfaces
{
    public interface IRPAQueueUserAuthenticationService
    {
        public Task<bool> CheckIfUserCanAuthenticateAsync(string userName, string password);
        public ApplicationUserViewModel MapModels(ApplicationUser userModel);
        public ApplicationUser MapModels(ApplicationUserViewModel userViewModel);
    }
}
