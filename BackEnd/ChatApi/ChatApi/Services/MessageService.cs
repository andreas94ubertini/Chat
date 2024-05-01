using ChatApi.Models;
using ChatApi.Repos;

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
    }
}
