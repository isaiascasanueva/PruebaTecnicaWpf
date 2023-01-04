using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnica
{
    class Peticiones
    {
        public object ObjetoString { get; set; }

        public string Url { get; set; }
        public object Objeto { get; set; }

        public async Task<string> ExecuteRequest(Result result)
        {
            string resultJson = "";
            try
            {
                HttpClient client = new HttpClient();

                client.BaseAddress = new Uri(this.Url);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpContent content = new StringContent("", Encoding.UTF8, "application/json");
                HttpResponseMessage response = client.GetAsync(this.Url).Result;

                if (response.IsSuccessStatusCode)
                {
                    resultJson = await response.Content.ReadAsStringAsync();
                    result.Correct = true;
                }
                else
                {
                    result.Correct = false;
                    result.Message = response.ReasonPhrase + " " + response.Content;
                }


            }
            catch (Exception ex)
            {
                result.Ex = ex;
                result.Message = ex.Message;
                result.Correct = false;
            }
            return resultJson;
        }
    }
}
