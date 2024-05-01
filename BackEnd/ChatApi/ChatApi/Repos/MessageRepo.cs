using ChatApi.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using SharpCompress.Common;

namespace ChatApi.Repos
{
    public class MessageRepo
    {
        #region Injection
        private IMongoCollection<Message> Message;
        private readonly ILogger _logger;

        public MessageRepo(IConfiguration configuration, ILogger<RoomRepo> logger)
        {
            this._logger = logger;

            string? connessioneLocale = configuration.GetValue<string>("ConnectionStrings:MongoDb");
            string? databaseName = configuration.GetValue<string>("ConnectionStrings:MongoDbName");

            MongoClient client = new MongoClient(connessioneLocale);
            IMongoDatabase _database = client.GetDatabase(databaseName);
            this.Message = _database.GetCollection<Message>("Message");

        }
        #endregion

        public bool InsertMessage(Message message) {
            try
            {
                Message.InsertOne(message);
                _logger.LogInformation("Inserimento effettuato con successo");
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return false;
        }

        public List<Message> GetMessages(ObjectId roomId)
        {
            var filter = Builders<Message>.Filter.Eq(m => m.RoomId, roomId);
            return Message.Find(filter).ToList();
        }
    }
}
