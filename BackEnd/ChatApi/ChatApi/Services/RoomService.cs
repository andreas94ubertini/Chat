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


        public bool Inserimento(ChatRoomDto objDto, string username)
        {
            ChatRoom c = new ChatRoom();
            c.Description = objDto.Des;
            c.RoomName = objDto.RoN;
            return _repo.Create(c, username);
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
                    Idc = c!.Id.ToString(),
                    RoN = c!.RoomName,
                    Des = c!.Description,
                    Use = c!.Users,
                    Messages = ConvertMsgToDto(c!.Messages)

                };
                return chat;
            }
            return null;
        }
        public bool InsertUserIntoChatRoom(string username, ObjectId roomId)
        {
            return _repo.InsertUserIntoChatRoom(username, roomId);
        }
        public List<ChatRoomDto>? GetRoomsByUser(string username) {
            List<ChatRoom>? chats = _repo.GetRoomByUser(username);
            List<ChatRoomDto>? chatsDto = new List<ChatRoomDto>();
            if(chats!= null)
            {
                foreach(ChatRoom chat in chats)
                {
                     ChatRoomDto ch = new ChatRoomDto()
                    {
                         Idc = chat.Id.ToString(),
                         RoN = chat.RoomName,
                         Des = chat.Description,
                         Use = chat.Users
                    };
                    chatsDto.Add(ch);
                }
            }
            return chatsDto;
        }
        
        public List<string>? GetUsersByRoom(ObjectId id) {
            return _repo.GetUtentiByRoom(id);
        }
    }
}
