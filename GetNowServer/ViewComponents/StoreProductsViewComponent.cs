using GetNowServer.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace GetNowServer
{
    [ViewComponent(Name = "StoreProductsViewComponent")]
    public class StoreProductsViewComponent : ViewComponent
    {
        public List<StoreProductView> storeProductViews = new List<StoreProductView>();
        public async Task<IViewComponentResult> InvokeAsync(int storeGroup, int storeProductGroup)
        {
            //(int storeGroup, int storeProductGroup) data = (storeGroup, storeProductGroup);

            var request = new HttpRequestMessage(HttpMethod.Get, Url.Action("Get", "StoreProductViews", null, Request.Scheme));
            request.Headers.Add("Accept", "application/json");
            //request.Headers.Add("User-Agent", "HttpClientFactory-Sample");
            request.Content = new FormUrlEncodedContent(new Dictionary<string, string>
            {
                { "storeGroup", storeGroup.ToString() },
                { "storeProductGroup", storeProductGroup.ToString() }
            });

            var client = new HttpClient();
            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                string responseBody = await response.Content.ReadAsStringAsync();
                storeProductViews = JsonConvert.DeserializeObject<List<StoreProductView>>(responseBody);
            }
            else
            {
            }
            return await Task.FromResult<IViewComponentResult>(View(storeProductViews));
        }
    }
}