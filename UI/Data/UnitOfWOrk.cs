using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

using UI.Data.Repositories.Classes;
using UI.Data.Repositories.Interfaces;

namespace UI.Data
{
    public class UnitOfWOrk: IUnitOfWork
    {
        
        private readonly IHttpClientFactory _clientFactory;
        private readonly string _route = "api/types/";
        public IAppUserRepository AppUsers { get; private set; }
        public IMoneyChangeRecordRepository MoneyChangeRecords { get; private set; }
        public IMoneyChangeTypeRepository MoneyChangeTypes { get; private set; }
        public UnitOfWOrk( HttpClient httpClient)
        {
            AppUsers = new AppUserRepository(httpClient, route: _route);
            MoneyChangeRecords = new MoneyChangeRecordRepository(httpClient, route: _route);
            MoneyChangeTypes = new MoneyChangeTypeRepository(httpClient, route: _route);
        }
    }
}
