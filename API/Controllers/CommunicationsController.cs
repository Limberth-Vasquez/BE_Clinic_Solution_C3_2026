using AppLogic;
using DTO;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [EnableCors("Demo_Policy")]
    [Route("api/[controller]")]
    [ApiController]
    public class CommunicationsController : ControllerBase
    {
        private readonly IEmailManager _emailManager;

        public CommunicationsController(IEmailManager emailManager)
        {
            _emailManager = emailManager;
        }


        [HttpGet("EnviarCorreo")]
        public ApiResponse SendEmail(string emailAddress)
        {
            var response = new ApiResponse();
            try
            {
                response.Data = _emailManager.SendEmail(emailAddress);
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
