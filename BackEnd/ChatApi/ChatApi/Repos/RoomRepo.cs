using ChatApi.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace ChatApi.Repos
{
    public class RoomRepo : IRepo<ChatRoom>
    {
        #region Injection
        private IMongoCollection<ChatRoom> Rooms;
        private readonly ILogger _logger;
        private readonly MessageRepo _messageRepo;

        public RoomRepo(IConfiguration configuration, ILogger<RoomRepo> logger, MessageRepo repo)
        {
            this._logger = logger;
            _messageRepo = repo;
            string? connessioneLocale = configuration.GetValue<string>("ConnectionStrings:MongoDb");
            string? databaseName = configuration.GetValue<string>("ConnectionStrings:MongoDbName");

            MongoClient client = new MongoClient(connessioneLocale);
            IMongoDatabase _database = client.GetDatabase(databaseName);
            this.Rooms = _database.GetCollection<ChatRoom>("Room");

        }
        #endregion
        public bool Create(ChatRoom entity, string username)
        {
            try
            {
                if (Rooms.Find(i => i.RoomName == entity.RoomName).ToList().Count > 0)
                    return false;
                
                entity.Users.Add(username);
                Rooms.InsertOne(entity);
                _logger.LogInformation("Inserimento effettuato con successo");
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return false;
        }

        public bool Delete(string codice)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ChatRoom> GetAll()
        {
            return Rooms.Find(p => true).ToList();
        }

        public ChatRoom? GetByCod(string codice)
        {
            throw new NotImplementedException();
        }

        public bool Update(ChatRoom entity)
        {
            throw new NotImplementedException();
        }

        public bool InsertUserIntoChatRoom(string username, ObjectId roomId)
        {
            ChatRoom? temp = GetById(roomId);
            if (temp != null)
            {
                //verificare presenza dell'utente nella lista
                temp.Users.Add(username);

                var filter = Builders<ChatRoom>.Filter.Eq(c => c.Id, temp.Id);
                try
                {
                    Rooms.ReplaceOne(filter, temp);
                    return true;
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex.Message);
                }
            }

            return false;
        }
        public ChatRoom? GetById(ObjectId id)
        {
            try
            {
                return Rooms.Find(i => i.Id== id).ToList()[0];
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }

        public ChatRoom? GetRoom(ObjectId id)
        {
            ChatRoom room = Rooms.Find(i => i.Id == id).ToList()[0];
            room.Messages = new List<Message>();
            room.Messages = _messageRepo.GetMessages(id);
            return room;
        }

        public List<ChatRoom>? GetRoomByUser(string username)
        {
            List<ChatRoom> rooms = new List<ChatRoom>();
            foreach(ChatRoom c in GetAll())
            {
                if (c.Users.Contains(username))
                {
                    rooms.Add(c);
                }
            }
            return rooms;
        }

        public bool Create(ChatRoom entity)
        {
            throw new NotImplementedException();
        }

        public List<string>? GetUtentiByRoom(ObjectId id) {
            ChatRoom? c = GetRoom(id);
            if(c != null)
                return c.Users;
            return null;
        
        }
    }
}
