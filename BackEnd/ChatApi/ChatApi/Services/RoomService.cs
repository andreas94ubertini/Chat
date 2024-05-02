using ChatApi.DTO;
using ChatApi.Models;
using ChatApi.Repos;
using MongoDB.Bson;
using System.Runtime.Intrinsics.Arm;
using System.Runtime.Intrinsics.X86;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ChatApi.Services
{
    public class RoomService
    {
        #region Injection
        private readonly RoomRepo _repo;

        public RoomService(RoomRepo repo)
        {
            _repo = repo;
        }
        #endregion


        public bool Inserimento(ChatRoom objDto)
        {

            return _repo.Create(objDto);
        }
        private List<MessageDto>? ConvertMsgToDto(List<Message>? messages)
        {
            List<MessageDto> elenco = new List<MessageDto>();
            if (messages != null)
            {
                foreach (Message m in messages)
                {
                    MessageDto msg = new MessageDto()
                    {
                        IdM = m.IdMessage.ToString(),
                        Tex = m.Text,
                        Dat = m.DataInvio,
                        Sen = m.Sender,
                        RoI = m.RoomId.ToString(),

                    };
                    elenco.Add(msg);
                }
            }
                return elenco;
            
        }
        public ChatRoomDto? GetRoom(ObjectId id) {
            ChatRoom? c = _repo.GetRoom(id);
            if (c != null)
            {
                ChatRoomDto chat = new ChatRoomDto()
                {
                    IdC = c!.Id.ToString(),
                    RoN = c!.RoomName,
                    Des = c!.Description,
                    Use = c!.Users,
                    Messages = ConvertMsgToDto(c!.Messages)

                };
                return chat;
            }
            return null;
        }

        public List<ChatRoom>? GetRoomsByUser(string username) {
            return _repo.GetRoomByUser(username);
        }
    }
}
