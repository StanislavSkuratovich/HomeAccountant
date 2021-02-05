using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Data.Entities;
using Core.Data.Repositories.Classes;
using Core.Data.Repositories.Interfaces;

namespace Core.Data.Repositories.Interfaces
{
    public interface IMoneyChangeRecordRepository: IRepository<MoneyChangeRecord>
    {
        Task<IEnumerable<MoneyChangeRecord>> GetChangesOfMonthAsync(DateTime dateTime);
        Task<IEnumerable<MoneyChangeRecord>> GetChangesOfDayAsync(DateTime dateTime);
    }
}
