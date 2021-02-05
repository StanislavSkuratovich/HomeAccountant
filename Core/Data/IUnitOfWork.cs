using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Core.Data.Repositories.Interfaces;

namespace Core.Data
{
    public interface IUnitOfWork : IDisposable
    {        
        IAppUserRepository AppUsers { get; }
        IMoneyChangeRecordRepository MoneyChangeRecords { get; }
        IMoneyChangeTypeRepository MoneyChangeTypes { get; }
        Task SaveChangesAsync();
    }
}
