using Microsoft.AspNetCore.Identity;

namespace Entities
{
    public class ECommerceUser : IdentityUser
    {
        public string FullName { get; set; }
        public string Address { get; set; }
        public int? PictureID { get; set; }
        public virtual Picture Picture { get; set; }

        public DateTime? RegisteredOn { get; set; }
    }

}
