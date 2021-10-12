using IEH_Identity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IEH_Identity.IService
{
   public interface IDataService
    {
        User GetUserById(string id);
        User GetUserByEmail(string Email);

    }
}
