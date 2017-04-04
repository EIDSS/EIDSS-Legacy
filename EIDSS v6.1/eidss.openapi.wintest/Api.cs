using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Http;
using Newtonsoft.Json;
using eidss.openapi.contract;

namespace eidss.openapi.wintest
{
    public class Api
    {
        private HttpClient _client;

        public Api(string url, string lng, string org, string usr, string pwd)
        {
            _client = new HttpClient() { BaseAddress = new Uri(url) };
            var authInfo = string.Format("{0}@{1}@{2}@{3}:{4}", org, usr, lng, "", pwd);
            var basic = string.Format("Basic {0}", Convert.ToBase64String(Encoding.Default.GetBytes(authInfo)));
            _client.DefaultRequestHeaders.Add("Authorization", basic);
        }

        public List<HumanCaseListItem> HumanCaseList(HumanCaseListFilter filter)
        {
            var customJsonSettings = new JsonSerializerSettings()
                {
                    DateTimeZoneHandling = DateTimeZoneHandling.Unspecified
                };

            var filterJson = string.Format("?filter={0}", JsonConvert.SerializeObject(filter, customJsonSettings));
            var response = _client.GetAsync("api/HumanCase/list" + filterJson).Result;  // Blocking call!
            if (response.IsSuccessStatusCode)
            {
                return response.Content.ReadAsAsync<IEnumerable<HumanCaseListItem>>().Result.ToList();
            }
            return null;
        }
    }
}
