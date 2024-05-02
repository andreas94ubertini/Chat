using ChatApi.Models;

namespace ChatApi.DTO
{
    public class UtentiDto
    {
        public string Us { get; set; } = null!;

        public string Ps { get; set; } = null!;

        public string? PI{ get; set; }

        public List<ChatRoom>? MyChats { get; set; }
    }
}
