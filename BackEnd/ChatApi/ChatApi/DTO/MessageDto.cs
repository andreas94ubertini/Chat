using MongoDB.Bson;

namespace ChatApi.DTO
{
    public class MessageDto
    {

        public ObjectId IdM { get; set; }

        public string? Tex { get; set; }

        public DateTime Dat { get; set; }

        public string? Sen { get; set; }

        public ObjectId RoI { get; set; }
    }
}
