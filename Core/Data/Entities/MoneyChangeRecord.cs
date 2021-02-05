using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Data.Entities
{
    public class MoneyChangeRecord
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public Int64 Amount { get; set; }// it means cents

        public DateTime Date { get; set; }//TODO
        public int MoneyChangeTypeId { get; set; }

        public MoneyChangeRecord()
        {
                
        }
    }
    
}
