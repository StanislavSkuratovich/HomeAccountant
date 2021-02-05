using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

using UI.Data.Entites;
using UI.Data.Repositories.Interfaces;

namespace UI.Data.Repositories.Classes
{
    public class MoneyChangeRecordRepository : BaseRepository<MoneyChangeRecord>, IMoneyChangeRecordRepository
    {
        public MoneyChangeRecordRepository(HttpClient client, string route) : base(client, route)
        {

        }
        public async Task<IEnumerable<MoneyChangeRecord>> GetByMonth(DateTime time)
        {
            var responce = await GetMonthlyRecords(time);
            var result = responce.Where(record=>record.Date.Value.Month == time.Month).ToList();
            return result;
        }

        public async Task<IEnumerable<MoneyChangeRecord>> GetByDay(DateTime time)
        {
            var responce = await GetMonthlyRecords(time);
            var result = responce.ToList();
            return result;
        }

        private async Task<IEnumerable<MoneyChangeRecord>> GetMonthlyRecords(DateTime date)
        {
            var particularRoute = _route + "ByMonth";
            var call = new HttpRequestMessage(HttpMethod.Get, particularRoute);
            var dateAsJson = JsonConvert.SerializeObject(date);
            call.Content = new StringContent(content: dateAsJson, encoding: Encoding.UTF8, mediaType: jsonType);
            HttpResponseMessage responseMessage = await _httpClient.SendAsync(call);
            var context = await responseMessage.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<IEnumerable<MoneyChangeRecord>>(context);
            return result;
        }
    }
}
