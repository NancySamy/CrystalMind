using CrystalMindTask.Dtos.Models;
using CrystalMindTask.WebApplication.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace CrystalMindTask.WebApplication.Controllers
{
    public class CustomerController : Controller
    {
        private ConfigURLs _configURLs;
        private IConfiguration _config;
        public CustomerController(IConfiguration configuration)
        {
            _config = configuration;

        }
        // GET: CustomerController
        public async Task<ActionResult> Index()
        {
            var configURLs = new ConfigURLs();
            configURLs.BaseURL = _config["ConfigURLs:BaseURL"];
            configURLs.GetCustomerUri = _config["ConfigURLs:GetCustomerUri"];
            GetCustomerResponseDto responseCustomers = new GetCustomerResponseDto();
            using (var client = new HttpClient())
            {
                //Passing service base url
                client.BaseAddress = new Uri(configURLs.BaseURL);
                client.DefaultRequestHeaders.Clear();
                //Define request data format
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //Sending request to find web api REST service resource GetAllEmployees using HttpClient
                HttpResponseMessage Res = await client.GetAsync(configURLs.GetCustomerUri);
                //Checking the response is successful or not which is sent using HttpClient
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api
                    var Response = Res.Content.ReadAsStringAsync().Result;
                    //Deserializing the response recieved from web api and storing into the Employee list
                    responseCustomers = JsonConvert.DeserializeObject<GetCustomerResponseDto>(Response);
                }
                //returning the employee list to view
            //    customers.Add(new CustomerRequestDto()
            //{
            //    CustomerFristName = "Nancy",
            //    CustomerLastName = "Samy",
            //    CustomerEmail = "ns900@gmail.com",
            //    CustomerDOB = DateTime.Now,
            //    CustomerGender = 'F'});
        }
                return View(responseCustomers.CustomersList);

    }

    // GET: CustomerController/Details/5
    public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CustomerController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CustomerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CustomerController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CustomerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CustomerController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CustomerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
