using Microsoft.AspNetCore.Mvc;
using Server.Service;

namespace Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlayerController : ControllerBase
    {
        private readonly PlayerService m_Service;

        public PlayerController(PlayerService service) 
        {
            m_Service = service;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok();//await m_Service.GetOne());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
