using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace ChatApi.Models
{
    public class ChatRoom
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; set; }

        [BsonElement("name")]
        public string? RoomName { get; set; }

        [BsonElement("description")]
        public string? Description { get; set; }

        public List<string> Users { get; set; } = new List<string>();

        [BsonRepresentation(BsonType.ObjectId)]
        public List<ObjectId> MessageID { get; set; } = new List<ObjectId>();

        public List<Message>? Messages { get; set; }


    }
}
