using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

using Core.Data.Entities;

using Microsoft.AspNetCore.Mvc;

using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Core.Controllers
{
    [Route("Home")]
    [ApiExplorerSettings(IgnoreApi = true)]// todo will have deal with swagger
    class HomeController : Controller
    {
        public HomeController()
        {
            var fodo = Request;
        }
        public async Task <IActionResult> Index()
        {
            return View();
        }

        private async Task<List<AppUser>> GetData()
        {
            var result = new List<AppUser>();
            var root = "https://" + Request.Host.Value;
            var endpoint = "api/users";
            HttpClient client = new HttpClient();
            try
            {
                client.BaseAddress = new Uri(root);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.GetAsync(endpoint);
                response.EnsureSuccessStatusCode();
                result = await response.Content.ReadAsAsync<List<AppUser>>();
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }       
    }
}
