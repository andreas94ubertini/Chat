using ChatApi.Models;
using ChatApi.Repos;
using ChatApi.Services;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

namespace ChatApi.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class RoomController : Controller
    {
        #region Injection
        private readonly RoomService _service;

        public RoomController(RoomService service)
        {
            _service = service;
        }
        #endregion
        [HttpPost]
        public IActionResult InserisciDipendente(ChatRoom newRoom)
        {

                if (_service.Inserimento(newRoom))
                    return Ok(new Risposta() { Status = "SUCCESS" });
            
            return BadRequest();
        }

        [HttpGet("chat/{id}")]
        public IActionResult GetRoomAndMessage(string id)
        {
            return Ok(new Risposta()
            {
                Status = "Success",
                Data = _service.GetRoom(new ObjectId(id))
            });
        }
    }
}
