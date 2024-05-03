using ChatApi.DTO;
using ChatApi.Filter;
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
        [AuthorizeUserType("USER")]

        public IActionResult NewChatRoom(ChatRoomDto newRoom)
        {
            try
            {
                if (User.Claims.FirstOrDefault(x => x.Type == "Username")?.Value != null)
                {
                    string username = User.Claims.First(x => x.Type == "Username").Value;
                    if (_service.Inserimento(newRoom, username))
                        return Ok(new Risposta() { Status = "SUCCESS" });
                }
            }catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

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

        [HttpPost("chat/addUser/{id}")]
        public IActionResult AddUserToChatRoom(string id, string username)
        {
            try
            {
                if (_service.InsertUserIntoChatRoom(username, new ObjectId(id)))
                return Ok(new Risposta()
                {
                    Status = "Success"
                });
            }catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return BadRequest();
        }
    }
}
