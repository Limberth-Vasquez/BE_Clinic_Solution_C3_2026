using AppLogic;
using DTO;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [EnableCors("Demo_Policy")]
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
        public async Task<ApiResponse> ReturnAllEmployess()
        {
            var response = new ApiResponse();
            try
            {
                response.Data = await _rhConnector.ReturnAllEmployees();
                response.Result = "ok";
            }
            catch (Exception ex)
            {
                response.Result = "error";
                response.Message = ex.Message + " " + ex.InnerException?.Message;
            }
            return response;
        }

        [HttpGet("ObtenerEspecialidades")]
        public async Task<ApiResponse> GetSpecialties()
        {
            var response = new ApiResponse();
            try
            {
                response.Data = await _rhConnector.GetSpecialties();
                response.Result = "ok";
            }
            catch (Exception ex)
            {
                response.Result = "error";
                response.Message = ex.Message + " " + ex.InnerException?.Message;
            }
            return response;
        }
    }
}
