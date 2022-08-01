using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace SilverhorseRecruitmentTest.Database
{
    public class DataIn
    {
        //Using RESTful HTTP Methods to recieve the data from the datasource, good for scalability
        private static HttpClient httpClient = new HttpClient();
        private static string defaultUrl = "https://jsonplaceholder.typicode.com/";
        private static HttpResponseMessage? response;

        //Used to recieve the list of data from the datasource
        public static async Task<string> Get(string dataName, int optionalId = 0)
        {
            string url = defaultUrl + dataName;

            if(optionalId != 0)
            {
                url += ("/" + optionalId.ToString());
            }

            response = await httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStringAsync();
        }

        //Used to add a specific object to the list of data
        public static async Task<string> Post(string dataName, object objectIn)
        {
            //Converting the Json Object
            HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(objectIn), Encoding.UTF8);
            response = await httpClient.PostAsync(defaultUrl + dataName, httpContent);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStringAsync();
        }

        //Used to update a specific id in the list of data
        public static async Task<string> Put(string dataName, object objectIn, int id)
        {
            HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(objectIn), Encoding.UTF8);
            response = await httpClient.PostAsync(defaultUrl + dataName + "/" + id.ToString(), httpContent);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStringAsync();
        }

        //Used to delete a resource within the list of data
        public static async Task<string> Delete(string dataName, int id)
        {
            response = await httpClient.DeleteAsync(defaultUrl + dataName + "/" + id.ToString());
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStringAsync();
        }
    }
}