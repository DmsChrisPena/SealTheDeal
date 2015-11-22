using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SealTheDeal.Data.Repositories
{
    public class UnitOfWork
    {
        public UserRepository User { get; set; }

        public UnitOfWork()
        {
            User = new UserRepository();
        }
    }
}
