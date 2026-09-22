using AppLogic;
using DTO;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RHController : ControllerBase
    {
        private readonly IRHConnector _rhConnector;

        public RHController(IRHConnector rhConnector)
        {
            _rhConnector = rhConnector;
        }

        [HttpGet("ObtenerTodosLosEmpleados")]
        public async Task<List<Employee>> ReturnAllEmployess()
        {
            return await _rhConnector.ReturnAllEmployees();
        }

        [HttpGet("ObtenerEspecialidades")]
        public async Task<List<string>> GetSpecialties()
        {
            return await _rhConnector.GetSpecialties();
        }
    }
}
