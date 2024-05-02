using MongoDB.Bson;

namespace ChatApi.DTO
{
    public class ChatRoomDto
    {
        public string? Idc { get; set; }

        public string? RoN { get; set; }

        public string? Des { get; set; }

        public List<string> Use { get; set; } = new List<string>();

        public List<ObjectId> MeI { get; set; } = new List<ObjectId>();

        public List<MessageDto>? Messages { get; set; }


    }
}
