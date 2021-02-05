using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Core.Data.Entities;
using Core.Data.Repositories.Classes;

namespace Core.Data.Repositories.Interfaces
{
    public interface IAppUserRepository: IRepository<AppUser>
    {
    }
}
