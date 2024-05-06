using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace ChatApi.Models
{
    public class Message
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId IdMessage { get; set; }

        [BsonElement("text")]
        public string? Text { get; set; }

        [BsonElement("dataInvio")]
        [BsonDateTimeOptions(DateOnly = true)]
        public DateTime DataInvio { get; set; } = DateTime.Now.Date;

        [BsonElement("sender")]
        public string? Sender { get; set; }
        [BsonElement("img")]
        public string? Img { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId RoomId { get; set;}

    }
}
