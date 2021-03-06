using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Weather.Models;

namespace Weather.Repositories
{
    class RepositoryContext
    {
        private readonly string _baseUrl;
        private readonly string _key;

        public RepositoryContext(string baseUrl, string key)
        {
            _baseUrl = baseUrl;
            _key = key;
        }

        public T[] GetData<T>(string param) where T : class
        {
            string result = string.Empty;
            bool isJsonArray = false;

            var uri = !string.IsNullOrEmpty(param) ? new Uri(string.Format("{0}?{1}&{2}", _baseUrl, _key, param)) : new Uri(string.Format("{0}?{1}", _baseUrl, _key));

            using (var client = new HttpClient())
            {
                result = client.GetStringAsync(uri).Result;
                isJsonArray = result.Substring(0, 1) == "[";
            }

            if (!isJsonArray)
            {
                result = string.Format("[{0}]", result);
            }

            return JsonSerializer.Deserialize<T[]>(result);
        }
    }
}
