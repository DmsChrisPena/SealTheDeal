using Microsoft.AspNet.Identity.EntityFramework;
using SealTheDeal.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SealTheDeal.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public IDbSet<Vendor> Vendors { get; set; }
        public IDbSet<Deal> Deals { get; set; }
        public IDbSet<UserDeal> UserDeals { get; set; }
        public IDbSet<Gender> Genders { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}
