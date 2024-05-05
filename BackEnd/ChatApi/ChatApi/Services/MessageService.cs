using ChatApi.Models;
using ChatApi.Repos;
using MongoDB.Bson;

namespace ChatApi.Services
{
    public class MessageService
    {
        #region Injection
        private readonly MessageRepo _repo;

        public MessageService(MessageRepo repo)
        {
            _repo = repo;
        }
        #endregion

        public bool InsertMessage(Message m)
        {

            return _repo.InsertMessage(m);
        }

        public bool DeleteMessage(ObjectId messageId, string username)
        {
            Message? m = _repo.GetOneMessage(messageId);
            if (m != null && m.Sender == username)
                return _repo.DeleteMessage(messageId);
            return false;
        }
    }
}
