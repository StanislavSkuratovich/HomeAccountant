using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Data.Entities;
using Core.Data.Repositories.Interfaces;

namespace Core.Data.Repositories.Classes
{
    public class AppUserRepository: Repository<AppUser>, IAppUserRepository
    {
        public AppUserRepository(DataContext context) : base(context)
        {

        }
    }
}
