using SealTheDeal.Models;
using SealTheDeal.Models.ViewModels.GetViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SealTheDeal.Data.Repositories
{
    public class UserRepository
    {
        private ApplicationDbContext _db;

        public UserRepository()
        {
            _db = new ApplicationDbContext();
        }

        public bool IsManager(string id)
        {
            ApplicationUser user = _db.Users.Where(u => u.Id == id).FirstOrDefault();

            return (user.Type.IsManager && !user.Type.IsDeleted);
        }

        public bool IsClerk(string id)
        {
            ApplicationUser user = _db.Users.Where(u => u.Id == id).FirstOrDefault();

            return (user.Type.IsClerk && !user.Type.IsClerk);
        }

        public bool IsCustomer(string id)
        {
            ApplicationUser user = _db.Users.Where(u => u.Id == id).FirstOrDefault();

            return (user.Type.IsCustomer && !user.Type.IsCustomer);
        }

        public RolesUVM GetRoles(string userName)
        {
            ApplicationUser user = _db.Users.Where(u => u.UserName == userName).FirstOrDefault();

            RolesUVM roles = new RolesUVM();

            roles.IsManager = user.Type.IsManager ? "true" : "false";
            roles.IsClerk = user.Type.IsClerk ? "true" : "false";
            roles.IsManager = user.Type.IsManager ? "true" : "false";

            return roles;
        }
    }
}
