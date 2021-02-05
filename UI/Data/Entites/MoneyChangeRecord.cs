using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UI.Data.Entites
{
    public class MoneyChangeRecord
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public Int64? Amount { get; set; }

        public DateTime? Date { get; set; } = DateTime.Today;
        public int? MoneyChangeTypeId { get; set; }
    }
}
