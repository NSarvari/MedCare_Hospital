using Microsoft.AspNetCore.Identity;

namespace MedCare_Hospital.DataStructure
{
    public class ApplicationUser:IdentityUser
    {
        public string? Name { get; set; }
        public string? ProfilePicture { get; set; }
    }
}
