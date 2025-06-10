using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Model;

namespace WeatherApp.ViewModel.Helpers
{
    public class AccuWeatherHelper
    {
        public const string api_key = "jBRKohc78gQa9c5eNPfEshGoGlM9jXKv";
        public const string base_url = "http://dataservice.accuweather.com/";

        #region Endpoints
        public const string autoComplete_endpoint = "locations/v1/cities/autocomplete?apikey={0}&q={1}";
        public const string currentConditions_endpoint = "currentconditions/v1/{0}?apikey={1}";
        #endregion

        #region Query methods
        public static async Task<List<City>?> GetCities(string query)
        {
            List<City>? cities = new List<City>();

            string url = base_url + string.Format(autoComplete_endpoint, api_key, query);

            using (HttpClient client = new HttpClient()) 
            {
                var response = await client.GetAsync(url);
                string json = await response.Content.ReadAsStringAsync();

                cities = JsonConvert.DeserializeObject<List<City>>(json);
            }

            return cities;
        }

        public static async Task<CurrentConditions?> GetCurrentConditions(string cityKey)
        {
            CurrentConditions? currentConditions = new CurrentConditions();

            string url = base_url + string.Format(currentConditions_endpoint, cityKey, api_key);

            using (HttpClient client = new HttpClient()) 
            {
                var response = await client.GetAsync(url);
                string json = await response.Content.ReadAsStringAsync();

                currentConditions = (JsonConvert.DeserializeObject<List<CurrentConditions>>(json)).FirstOrDefault();
            }

            return currentConditions;
        }
        #endregion
    }
}
