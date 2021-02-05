using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

using UI.Data.Entites;
using UI.Data.Repositories.Interfaces;

namespace UI.Data.Repositories.Classes
{
    public class MoneyChangeTypeRepository : BaseRepository<MoneyChangeType>, IMoneyChangeTypeRepository
    {
        public MoneyChangeTypeRepository(HttpClient client, string route) : base(client, route)
        {

        }
    }
}
