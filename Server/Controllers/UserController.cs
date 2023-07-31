using Microsoft.AspNetCore.Mvc;
using Server.Models;
using Server.Service;

namespace Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UsersService m_Service;

        public UserController(UsersService rep)
        {
            m_Service = rep;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await m_Service.GetAll());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{i}")]
        public async Task<IActionResult> GetByID(int id)
        {
            try
            {
                return Ok(await m_Service.GetById(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            //Task<int> getByID(int id)

            // return await m_Service.GetById(id)
        }
        [HttpPost("create")]
        public async Task<IActionResult> CreateUser(RegUser user)
        {
            try
            {
                return Ok(await m_Service.Create(user));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("update")]
        public async Task<IActionResult> UpdateUser(UserEntity user)
        {
            try
            {
                return Ok(await m_Service.Update(user));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            try
            {
                return Ok(await m_Service.Delete(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
