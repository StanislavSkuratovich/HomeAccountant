using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Core.Data.Repositories.Classes;
using Core.Data.Repositories.Interfaces;

using Microsoft.EntityFrameworkCore;

namespace Core.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;

        public IAppUserRepository AppUsers { get; private set; }
        public IMoneyChangeRecordRepository MoneyChangeRecords { get; private set; }
        public IMoneyChangeTypeRepository MoneyChangeTypes { get; private set; }
        public UnitOfWork(DataContext context)// every repository should be consructed there
        {
            _context = context;
            AppUsers = new AppUserRepository(_context);
            MoneyChangeRecords = new MoneyChangeRecordRepository(_context);
            MoneyChangeTypes = new MoneyChangeTypeRepository(_context);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
