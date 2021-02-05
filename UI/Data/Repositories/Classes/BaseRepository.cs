using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

using UI.Data.Repositories.Interfaces;

namespace UI.Data.Repositories.Classes
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        internal readonly string jsonType = "application/json";
        internal readonly string _route;
        internal readonly HttpClient _httpClient;

        public BaseRepository(HttpClient httpClient, string apiRoute)
        {
            _httpClient = httpClient;
            _route = httpClient.BaseAddress.ToString() + apiRoute;

        }

        public async Task<bool> AddAsync(TEntity entity)
        {
            var call = new HttpRequestMessage(HttpMethod.Post, _route);
            if (null == entity)
            {
                return false;
            }
            var recordAsJson = JsonConvert.SerializeObject(entity);
            call.Content = new StringContent(content: recordAsJson, encoding: Encoding.UTF8, mediaType: jsonType);
            HttpResponseMessage responseMessage = await _httpClient.SendAsync(call);
            if (responseMessage.StatusCode == System.Net.HttpStatusCode.Created)
            {
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            var call = new HttpRequestMessage(HttpMethod.Get, _route);
            HttpResponseMessage responseMessage = await _httpClient.SendAsync(call);
            var context = await responseMessage.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<TEntity>>(context);
            return result;
        }

        public async Task<TEntity> GetAsync(int id)
        {
            var call = new HttpRequestMessage(HttpMethod.Get, _route + id);
            HttpResponseMessage responseMessage = await _httpClient.SendAsync(call);
            var content = await responseMessage.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<TEntity>(content);
            return result;
        }

        public async Task<bool> RemoteAsync(int id)
        {
            var call = new HttpRequestMessage(HttpMethod.Delete, _route + id);
            HttpResponseMessage responseMessage = await _httpClient.SendAsync(call);
            var resultStatusCode = responseMessage.StatusCode;
            if (resultStatusCode == System.Net.HttpStatusCode.NoContent)
            {
                return false;
            }
            return true;
        }

        public async Task<bool> UpdateAsync(TEntity entity, int id)
        {
            var call = new HttpRequestMessage(HttpMethod.Put, _route + id);
            if (null == entity)
            {
                return false;
            }
            var entityAsJson = JsonConvert.SerializeObject(entity);
            call.Content = new StringContent(content: entityAsJson, encoding: Encoding.UTF8, mediaType: jsonType);
            HttpResponseMessage responseMessage = await _httpClient.SendAsync(call);
            if (responseMessage.StatusCode == System.Net.HttpStatusCode.NoContent)
            {
                return false;
            }
            return true;
        }
    }
}
