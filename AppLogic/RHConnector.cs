using DTO;
using Newtonsoft.Json;

namespace AppLogic
{
    public interface IRHConnector
    {
        Task<List<Employee>> ReturnAllEmployees();
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
            string resultado = await _httpClient.GetStringAsync(serviceUrl);
            var dtoObject = JsonConvert.DeserializeObject<List<Employee>>(resultado);
            return dtoObject;
        }
    }
}
