using DTO;
using Newtonsoft.Json;

namespace AppLogic
{
    public interface IRHConnector
    {
        Task<List<Employee>> ReturnAllEmployees();
        Task<List<string>> GetSpecialties();
    }
    public class RHConnector : IRHConnector
    {
        private static HttpClient? _httpClient; 
        private string _url = "https://rh-central.azurewebsites.net";

        public RHConnector() 
        {
            if (_httpClient == null)
            {
                _httpClient = new HttpClient()
                {
                    Timeout = new TimeSpan(0,0,10),
                    BaseAddress = new Uri(_url)
                };
            }
        }

        public async Task<List<Employee>> ReturnAllEmployees()
        {
            string serviceUrl = "/api/RH/GetAllEmployees";
            string resultado = await InvokeGetAsync(serviceUrl);
            var dtoObject = JsonConvert.DeserializeObject<List<Employee>>(resultado);
            return dtoObject;
        }
        public async Task<List<string>> GetSpecialties()
        {
            string serviceUrl = "/api/RH/GetSpecialties";
            string resultado = await InvokeGetAsync(serviceUrl);
            var specialitiesStrings = JsonConvert.DeserializeObject<List<string>>(resultado);
            return specialitiesStrings;
        }

        #region Metodos helpers
        private async Task<string> InvokeGetAsync(string uri) 
        {
            try
            {
                string response = string.Empty;
                var results = await _httpClient.GetAsync(uri);
                if(results.IsSuccessStatusCode) 
                {
                    response = await results.Content.ReadAsStringAsync();
                }

                return response;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        private async Task<string> InvokePutAsync(string uri, StringContent content)
        {
            try
            {
                string response = string.Empty;
                var results = await _httpClient.PutAsync(uri, content);
                if (results.IsSuccessStatusCode)
                {
                    response = await results.Content.ReadAsStringAsync();
                }

                return response;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        private async Task<string> InvokePostAsync(string uri, StringContent content)
        {
            try
            {
                string response = string.Empty;
                var results = await _httpClient.PostAsync(uri, content);
                if (results.IsSuccessStatusCode)
                {
                    response = await results.Content.ReadAsStringAsync();
                }

                return response;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        #endregion Metodos helpers
    }
}
