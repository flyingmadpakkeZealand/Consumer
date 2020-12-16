using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ModelLibPlants
{
    public class Consumer : ConsumerBase
    {
        private string URL;

        public Consumer(string url)
        {
            URL = url;
        }

        public async Task<TOut> GetAsync<TOut>()
        {
            using (HttpClient client = new HttpClient())
            {
                return await HandleHTTPResponseAsync<TOut>(() => client.GetAsync(URL));
            }
        }

        public async Task<TOut> GetAsync<TOut>(string uri)
        {
            using (HttpClient client = new HttpClient())
            {
                return await HandleHTTPResponseAsync<TOut>(() => client.GetAsync(URL + uri));
            }
        }

        public async Task PostAsync<TIn>(TIn item)
        {
            StringContent content = EncodeContent(item);
            using (HttpClient client = new HttpClient())
            {
                await HandleHTTPResponseAsync(() => client.PostAsync(URL, content));
            }
        }

        public async Task<TOut> PostAsync<TIn, TOut>(TIn item)
        {
            StringContent content = EncodeContent(item);
            using (HttpClient client = new HttpClient())
            {
                return await HandleHTTPResponseAsync<TOut>(() => client.PostAsync(URL, content));
            }
        }

        public async Task PostAsync<TIn>(TIn item, string uri)
        {
            StringContent content = EncodeContent(item);
            using (HttpClient client = new HttpClient())
            {
                await HandleHTTPResponseAsync(() => client.PostAsync(URL + uri, content));
            }
        }

        public async Task<TOut> PostAsync<TIn, TOut>(TIn item, string uri)
        {
            StringContent content = EncodeContent(item);
            using (HttpClient client = new HttpClient())
            {
                return await HandleHTTPResponseAsync<TOut>(() => client.PostAsync(URL + uri, content));
            }
        }

        public async Task PutAsync<TIn>(TIn item)
        {
            StringContent content = EncodeContent(item);
            using (HttpClient client = new HttpClient())
            {
                await HandleHTTPResponseAsync(() => client.PutAsync(URL, content));
            }
        }

        public async Task<TOut> PutAsync<TIn, TOut>(TIn item)
        {
            StringContent content = EncodeContent(item);
            using (HttpClient client = new HttpClient())
            {
                return await HandleHTTPResponseAsync<TOut>(() => client.PutAsync(URL, content));
            }
        }

        public async Task PutAsync<TIn>(TIn item, string uri)
        {
            StringContent content = EncodeContent(item);
            using (HttpClient client = new HttpClient())
            {
                await HandleHTTPResponseAsync(() => client.PutAsync(URL + uri, content));
            }
        }

        public async Task<TOut> PutAsync<TIn, TOut>(TIn item, string uri)
        {
            StringContent content = EncodeContent(item);
            using (HttpClient client = new HttpClient())
            {
                return await HandleHTTPResponseAsync<TOut>(() => client.PutAsync(URL + uri, content));
            }
        }

        public async Task DeleteAsync()
        {
            using (HttpClient client = new HttpClient())
            {
                await HandleHTTPResponseAsync(() => client.DeleteAsync(URL));
            }
        }

        public async Task<TOut> DeleteAsync<TOut>()
        {
            using (HttpClient client = new HttpClient())
            {
                return await HandleHTTPResponseAsync<TOut>(() => client.DeleteAsync(URL));
            }
        }

        public async Task DeleteAsync(string uri)
        {
            using (HttpClient client = new HttpClient())
            {
                await HandleHTTPResponseAsync(() => client.DeleteAsync(URL + uri));
            }
        }

        public async Task<TOut> DeleteAsync<TOut>(string uri)
        {
            using (HttpClient client = new HttpClient())
            {
                return await HandleHTTPResponseAsync<TOut>(() => client.DeleteAsync(URL + uri));
            }
        }
    }
}
