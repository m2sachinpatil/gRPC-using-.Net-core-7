using gRPC_Front_End.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace gRPC_Front_End.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public HomeController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<ActionResult> Home()
        {
            List<MeterUsageModel> result = new();
            try
            {
                using var client = _httpClientFactory.CreateClient();

                client.BaseAddress = new Uri(Constant.Baseurl);
                client.DefaultRequestHeaders.Clear();

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync("MeterUsage");

                if (response.IsSuccessStatusCode)
                {

                    // var content = response.Content.ReadAsStringAsync().Result;
                    // var jsonResult = JsonConvert.DeserializeObject(content).ToString();
                    // result = JsonConvert.DeserializeObject<MeterUsageModel>(jsonResult);

                    var responseString = response.Content.ReadAsStringAsync().Result;
                    var responseData = JsonConvert.DeserializeObject<string>(responseString);
                    result = JsonConvert.DeserializeObject<List<MeterUsageModel>>(responseData);

                    return View(result);
                }
            }
            catch (Exception)
            {
                throw;
            }


        }
    }
}