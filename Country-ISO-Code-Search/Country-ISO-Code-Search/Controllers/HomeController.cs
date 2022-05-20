using Country_ISO_Code_Search.Models;
using CountryISOSearch.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Country_ISO_Code_Search.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            List<Country> countryList = new();
            using (var httpClient = new HttpClient())
            {
                using var response = await httpClient.GetAsync("http://api.worldbank.org/v2/country?format=json");
                var responseString = await response.Content.ReadAsStringAsync();

                // parse the response string into a jarray
                JArray array = JArray.Parse(responseString);

                // select the Jarray data for the list of countries
                var countries = array[1].Children<JObject>();

                foreach (JObject country in countries)
                {
                    // format the country JObject
                    var serializedCountryObj = JsonConvert.SerializeObject(country);
                    // convert the country json data into a country Object
                    var ListObjCountry = JsonConvert.DeserializeObject<Country>(serializedCountryObj);

                    // add the country object to the list collection
                    countryList.Add(ListObjCountry);
                }
            }

            return View(countryList);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
