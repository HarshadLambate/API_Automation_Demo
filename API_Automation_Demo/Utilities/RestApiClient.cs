using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace API_Automation_Demo.Utilities
{
    public class RestApiClient
    {
        private HttpClient httpClient;
        public RestApiClient(string baseUrl)
        {
            httpClient = new HttpClient { BaseAddress = new Uri(baseUrl) };
        }

        // Send a GET request to the API
        public async Task<HttpResponseMessage> Get(string endpoint)
        {
            HttpResponseMessage response = await httpClient.GetAsync(endpoint);
            response.EnsureSuccessStatusCode();
            return response;
        }

        // Overloaded method to send a GET request with query parameters
        public async Task<HttpResponseMessage> Get(string endpoint, string queryParams)
        {
            HttpResponseMessage response = await httpClient.GetAsync($"{endpoint}?{queryParams}");
            response.EnsureSuccessStatusCode();
            return response;
        }

        // Send a POST request to the API with a JSON payload
        public async Task<HttpResponseMessage> Post(string endpoint, string jsonPayload)
        {
            HttpContent content = new StringContent(jsonPayload, System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = await httpClient.PostAsync(endpoint, content);
            response.EnsureSuccessStatusCode();
            return response;
        }

        // Send a DELETE request to the API
        public async Task<HttpResponseMessage> Delete(string endpoint)
        {
            HttpResponseMessage response = await httpClient.DeleteAsync(endpoint);
            response.EnsureSuccessStatusCode();
            return response;
        }
    }
}
