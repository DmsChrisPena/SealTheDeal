using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SealTheDeal.Models
{
    public class Universe
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
    }

    public class Vendor : Universe
    {
        public Address Address { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Website { get; set; }
        public DateTime ClosingTime { get; set; }

        // Managers and Bartenders
        public virtual ICollection<ApplicationUser> Users { get; set; }
        public virtual ICollection<Deal> Deals { get; set; }
    }

    public class Deal : Universe
    {
        public string Title { get; set; }
        public string Detail { get; set; }
        public string ImageUrl { get; set; }
        public int Points { get; set; }
        public DateTime Begin { get; set; }
        public DateTime End { get; set; }
        public int Limit { get; set; }
        public DateTime TimeCreated { get; set; }

        [ForeignKey("Manager")]
        public string ManagerId { get; set; }
        public virtual ApplicationUser Manager { get; set; }

        public virtual ICollection<UserDeal> Users { get; set; }
    }

    public class UserDeal : Universe
    {
        public string Code { get; set; }
        public DateTime TimeCreated { get; set; }
        public DateTime TimeRedeemed { get; set; }

        [ForeignKey("Deal")]
        public int DealId { get; set; }
        public virtual Deal Deal { get; set; }

        [ForeignKey("Customer")]
        public string CustomerId { get; set; }
        public virtual ApplicationUser Customer { get; set; }

        [ForeignKey("Clerk")]
        public string ClerkId { get; set; }
        public virtual ApplicationUser Clerk { get; set; }
    }

    public class Gender : Universe
    {
        public string Name { get; set; }
    }
}
