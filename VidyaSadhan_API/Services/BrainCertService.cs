using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using VidyaSadhan_API.Models;

namespace VidyaSadhan_API.Services
{
    public class BrainCertService
    {
        private readonly BrainCertOptions _config;
        public BrainCertService(IOptions<BrainCertOptions> config)
        {
            _config = config.Value;
        }

        public async Task<bool> CreateClass(ClassRequestModel_B classRequest)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_config.URL);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.AcceptLanguage.Add(new StringWithQualityHeaderValue("nl-NL"));

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await client.
                    PostAsync(string.Format("v2/schedule?apikey={0}&title={1}&timezone={2}&date={3}&start_time={4}&end_time={5}",
                   _config.ClientKey, classRequest.title, classRequest.timezone, classRequest.date, classRequest.start_time, classRequest.end_time), null);
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                }
            }
            return true;
        }

        public async Task<ClassResponseViewModel_B> GetClassList()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_config.URL);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.AcceptLanguage.Add(new StringWithQualityHeaderValue("nl-NL"));

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await client.
                    PostAsync(string.Format("v2/listclass?apikey={0}",
                   _config.ClientKey), null);
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                }
            }

            return null;
        }
    }
}
