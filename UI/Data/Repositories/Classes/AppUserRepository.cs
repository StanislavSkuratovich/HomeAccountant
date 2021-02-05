using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

using UI.Data.Entites;
using UI.Data.Repositories.Interfaces;

namespace UI.Data.Repositories.Classes
{
    public class AppUserRepository : BaseRepository<AppUser>, IAppUserRepository
    {
        public AppUserRepository(HttpClient client, string route) : base(client, route)
        {

        }
    }
}
