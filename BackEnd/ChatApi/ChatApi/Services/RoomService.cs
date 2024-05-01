using ChatApi.Models;
using ChatApi.Repos;
using MongoDB.Bson;

namespace ChatApi.Services
{
    public class RoomService
    {
        #region Injection
        private readonly RoomRepo _repo;

        public RoomService(RoomRepo repo)
        {
            _repo = repo;
        }
        #endregion

        public bool Inserimento(ChatRoom objDto)
        {

            return _repo.Create(objDto);
        }

        public ChatRoom? GetRoom(ObjectId id) {
            return _repo.GetRoom(id);
        }
    }
}
