using ChatApi.Filter;
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
        [AuthorizeUserType("USER")]
        public IActionResult InserisciMessaggio(Message m, string roomID)
        {
            try
            {
                var us = User.Claims.FirstOrDefault(x => x.Type == "Username")?.Value;
                if(us != null)
                {
                    m.Sender = User.Claims.First(x => x.Type == "Username").Value;
                    m.RoomId = new MongoDB.Bson.ObjectId(roomID);
                    if (_service.InsertMessage(m))
                        return Ok(new Risposta() { Status = "SUCCESS" });
                }
            }catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());

            }
            return BadRequest();
        }

        [HttpDelete("eliminaMessaggio/{id}")]
        [AuthorizeUserType("USER")]
        public IActionResult DeleteMessage(string id)
        {
            try
            {
                var us = User.Claims.FirstOrDefault(x => x.Type == "Username")?.Value;
                if (us != null)
                {
                    if (_service.DeleteMessage(new MongoDB.Bson.ObjectId(id), us))
                        return Ok(new Risposta() { Status = "SUCCESS" });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());

            }
            return BadRequest();
        }

    }
}
