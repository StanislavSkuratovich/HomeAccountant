using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Data.Entities;
using Core.Data.Repositories.Interfaces;

namespace Core.Data.Repositories.Classes
{
    public class MoneyChangeRecordRepository: Repository<MoneyChangeRecord>, IMoneyChangeRecordRepository
    {
        public MoneyChangeRecordRepository(DataContext context) : base(context)
        {

        }

        private IQueryable<MoneyChangeRecord> GetChangesOfMonth(DateTime dateTime)
        {
            var YearRecordsOfComparedDate = Context.Set<MoneyChangeRecord>().Where(records => records.Date.Year == dateTime.Year);
            var MonthRecordsOfComparedDate = YearRecordsOfComparedDate.Where(records => records.Date.Month == dateTime.Month);
            return MonthRecordsOfComparedDate;
        }

        public async Task<IEnumerable<MoneyChangeRecord>> GetChangesOfMonthAsync(DateTime dateTime)
        {
            var querry = await Task.FromResult(GetChangesOfMonth(dateTime));
            var result = querry.ToList();
            return result;
        }
        public async Task<IEnumerable<MoneyChangeRecord>> GetChangesOfDayAsync(DateTime dateTime)
        {
            var monthRecords = await Task.FromResult(GetChangesOfMonth(dateTime));
            var result = await Task.FromResult(monthRecords.Where(records => records.Date.Day == dateTime.Day));
            return result.ToList();
        }
    }
}
