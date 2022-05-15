using CrystalMindTask.Dtos.Models;
using CrystalMindTask.WebApp.Helpers;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace CrystalMindTask.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private ConfigURLs _configURLs;
        public HomeController(ConfigURLs configURLs1)
        {
            _configURLs=configURLs1;
        }
        public async Task<ViewResult> Details()
        {
            List<CustomerRequestDto> customers = new List<CustomerRequestDto>();
            using (var client = new HttpClient())
            {
                //Passing service base url
                client.BaseAddress = new Uri(_configURLs.BaseURL);
                client.DefaultRequestHeaders.Clear();
                //Define request data format
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //Sending request to find web api REST service resource GetAllEmployees using HttpClient
                HttpResponseMessage Res = await client.GetAsync(_configURLs.GetCustomerUri);
                //Checking the response is successful or not which is sent using HttpClient
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api
                    var Response = Res.Content.ReadAsStringAsync().Result;
                    //Deserializing the response recieved from web api and storing into the Employee list
                    customers = JsonConvert.DeserializeObject<List<CustomerRequestDto>>(Response);
                }
                //returning the employee list to view
                return View(customers);
            }
        }
    }
}
