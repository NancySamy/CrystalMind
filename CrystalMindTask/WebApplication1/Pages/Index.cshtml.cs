using CrystalMindTask.Dtos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using WebApplication1.Helpers;

namespace WebApplication1.Pages
{
    public class IndexModel : PageModel
    {
        private IConfiguration _config;
        public GetCustomerResponseDto responseCustomers = new GetCustomerResponseDto();

        public IndexModel(IConfiguration configuration)
        {
            _config = configuration;

        }

        public async Task<IActionResult>  OnGet()
        {
            var configURLs = new ConfigURLs();
            configURLs.BaseURL = _config["ConfigURLs:BaseURL"];
            configURLs.GetCustomerUri = _config["ConfigURLs:GetCustomerUri"];
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(configURLs.BaseURL);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync(configURLs.GetCustomerUri);
                if (Res.IsSuccessStatusCode)
                {
                    var Response = Res.Content.ReadAsStringAsync().Result;
                    responseCustomers = JsonConvert.DeserializeObject<GetCustomerResponseDto>(Response);
                }
                return Page();
            }
        }
    }
}