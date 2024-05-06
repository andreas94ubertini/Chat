using ChatApi.Models;

namespace ChatApi.DTO
{
    public class UtentiDto
    {
        public string Us { get; set; } = null!;

        public string Ps { get; set; } = null!;

        public string? Pi { get; set; }

        public List<ChatRoomDto>? MyChats { get; set; }
    }
}
