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
        private readonly UserRepo _userRepo;

        public MessageRepo(IConfiguration configuration, ILogger<RoomRepo> logger, UserRepo userRepo)
        {
            this._logger = logger;

            string? connessioneLocale = configuration.GetValue<string>("ConnectionStrings:MongoDb");
            string? databaseName = configuration.GetValue<string>("ConnectionStrings:MongoDbName");

            MongoClient client = new MongoClient(connessioneLocale);
            IMongoDatabase _database = client.GetDatabase(databaseName);
            this.Message = _database.GetCollection<Message>("Message");
            _userRepo = userRepo;
        }
        #endregion

        public bool InsertMessage(Message message)
        {
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
            List<Message> m = Message.Find(filter).ToList();
            List<Utenti> u = _userRepo.GetAll().ToList();
            foreach(Message ms in m)
            {
                foreach(Utenti ut in u)
                {
                    if(ms.Sender == ut.Username)
                    {
                        ms.Img = ut.ProfileImg;
                    }
                }
            }
            return m;
        }
        public Message? GetOneMessage(ObjectId messageId) {
            var filter = Builders<Message>.Filter.Eq(m => m.IdMessage, messageId);
            try
            {
                return Message.Find(filter).ToList()[0];
                
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return null;
        }
        public bool DeleteMessage(ObjectId messageId)
        {
            var filter = Builders<Message>.Filter.Eq(m => m.IdMessage, messageId);
            try
            {
                Message.DeleteOne(filter);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return false;
        }
    }
}
