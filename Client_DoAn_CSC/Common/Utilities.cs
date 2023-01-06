using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Client_DoAn_CSC.Common
{
    public class Utilities
    {
        public static string ServiceURL { get; set; }

        public static T SendDataRequest<T>(string APIUrl, object input = null)
        {
            HttpClient client = new();
            client.BaseAddress = new Uri(ServiceURL);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.PostAsJsonAsync(APIUrl, input).Result;
            T kq = default(T);
            if (response.IsSuccessStatusCode)
                kq = response.Content.ReadFromJsonAsync<T>().Result;
            return kq;
        }
    }
}
