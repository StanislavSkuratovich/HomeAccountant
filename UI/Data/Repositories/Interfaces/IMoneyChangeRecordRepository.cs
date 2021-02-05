using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using UI.Data.Entites;

namespace UI.Data.Repositories.Interfaces
{
    public interface IMoneyChangeRecordRepository: IBaseRepository<MoneyChangeRecord>
    {
        Task<IEnumerable<MoneyChangeRecord>> GetByMonth(DateTime time);
        Task<IEnumerable<MoneyChangeRecord>> GetByDay(DateTime time);
    }
}
