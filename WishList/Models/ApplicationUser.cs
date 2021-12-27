using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace WishList.Models
{
    public class ApplicationUser : IdentityUser
    {
        public virtual ICollection<Item> Item { get; set;}
    }
}
