using Microsoft.AspNetCore.Identity;

namespace RPA_Queue.ViewModels
{
    public class ApplicationUserViewModel : IdentityUser
    {
        public bool FoundInLocalDB { get; set; } = false;
    }
}
