using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ModelLibPlants
{
    public abstract class ConsumerBase
    {
        protected virtual async Task<TOut> HandleHTTPResponseAsync<TOut>(Func<Task<HttpResponseMessage>> requestFunc)
        {
            HttpResponseMessage response = await requestFunc();
            if (response.IsSuccessStatusCode)
            {
                string jsonString = await response.Content.ReadAsStringAsync();
                TOut content = JsonConvert.DeserializeObject<TOut>(jsonString);
                return content;
            }
            throw new HttpRequestException(response.StatusCode.ToString());
        }

        protected virtual async Task HandleHTTPResponseAsync(Func<Task<HttpResponseMessage>> requestFunc)
        {
            HttpResponseMessage response = await requestFunc();
            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException(response.StatusCode.ToString());
            }
        }
        
        protected virtual StringContent EncodeContent<TIn>(TIn item)
        {
            string jsonStr = JsonConvert.SerializeObject(item);
            StringContent content = new StringContent(jsonStr, Encoding.UTF8, "application/json");
            return content;
        }
    }
}
