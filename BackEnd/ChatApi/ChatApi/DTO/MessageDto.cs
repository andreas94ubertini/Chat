using MongoDB.Bson;

namespace ChatApi.DTO
{
    public class MessageDto
    {

        public string? IdM { get; set; }

        public string? Tex { get; set; }

        public DateTime Dat { get; set; }

        public string? Sen { get; set; }

        public string? RoI { get; set; }
    }
}
