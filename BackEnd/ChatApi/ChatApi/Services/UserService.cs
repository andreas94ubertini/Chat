using ChatApi.DTO;
using ChatApi.Models;
using ChatApi.Repos;
using System.Runtime.CompilerServices;

namespace ChatApi.Services
{
    public class UserService
    {
        #region Injection
        private readonly UserRepo _repo;

        public UserService(UserRepo repository)
        {
            _repo = repository;
        }
        #endregion

        public bool Create(UtentiDto newUser)
        {
            Utenti u = new Utenti()
            {
                Username = newUser.Us,
                Psw = newUser.Ps
            };
            return _repo.Create(u);

        }

        public bool LoginUtente(UserLoginModel obj)
        {
            string md5Hash = MD5Helper.CalculateMD5(obj.Password);
            obj.Password = md5Hash;
            
            return _repo.CheckLogin(obj) is not null ? true : false;
        }

        public Utenti? GetUtente(string username)
        {
            return _repo.GetByUsername(username);
        }
    }
}
