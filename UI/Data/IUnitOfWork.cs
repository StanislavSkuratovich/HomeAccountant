using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using UI.Data.Repositories.Interfaces;

namespace UI.Data
{
    public interface IUnitOfWork
    {
        IAppUserRepository AppUsers { get; }
        IMoneyChangeRecordRepository MoneyChangeRecords { get; }
        IMoneyChangeTypeRepository MoneyChangeTypes { get; }
    }
}
