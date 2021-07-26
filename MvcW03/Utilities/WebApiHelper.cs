using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MvcW03.Utilities
{
    public class WebApiHelper
    {
        public readonly HttpClient _client;

        public WebApiHelper()
        {
            var address = "http://localhost:5000";
            _client = new HttpClient()
            {
                BaseAddress = new Uri(address),
                
            };
            
        }

        public T Read<T>(string controller,string action,string filter)
        {
            var query = $"api/{controller}/{action}?filter={filter}";
            var response = _client.GetAsync(query).Result;
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Data can not retrieved from api");
            }

            return JsonConvert.DeserializeObject<T>(response.Content.ReadAsStringAsync().Result);
        }
        
        public T Modify<T>(string controller, string action, T data)
        {
            var query = $"api/{controller}/{action}";
            var jsonString = JsonConvert.SerializeObject(data);
            var json=new StringContent(JsonConvert.SerializeObject(data),Encoding.UTF8,"application/json");
            var response = _client.PostAsync(query, json).Result;
            return JsonConvert.DeserializeObject<T>(response.Content.ReadAsStringAsync().Result);
        }
    }
}
