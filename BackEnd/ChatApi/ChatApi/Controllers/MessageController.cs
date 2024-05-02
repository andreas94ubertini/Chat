using ChatApi.Models;
using ChatApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace ChatApi.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class MessageController : Controller
    {
        #region Injection
        private readonly MessageService _service;

        public MessageController(MessageService service)
        {
            _service = service;
        }
        #endregion
        [HttpPost("sendMessage/{roomID}")]
        public IActionResult InserisciMessaggio(Message m, string roomID)
        {
            if (User.Claims.FirstOrDefault(x => x.Type == "Username")?.Value != null)
            {
                m.Sender = User.Claims.First(x => x.Type == "Username").Value;

            }
            m.RoomId = new MongoDB.Bson.ObjectId(roomID);
            if (_service.InsertMessage(m))
                return Ok(new Risposta() { Status = "SUCCESS" });

            return BadRequest();
        }
    }
}
