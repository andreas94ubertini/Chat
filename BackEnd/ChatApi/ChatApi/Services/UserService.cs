using ChatApi.DTO;
using ChatApi.Models;
using ChatApi.Repos;
using MongoDB.Bson;
using System.Runtime.CompilerServices;

namespace ChatApi.Services
{
    public class UserService
    {
        #region Injection
        private readonly UserRepo _repo;
        private readonly RoomService _roomService;

        public UserService(UserRepo repository, RoomService roomService)
        {
            _repo = repository;
            _roomService = roomService;
        }
        #endregion


        public bool Create(UtentiDto newUser)
        { 
            if (GetUtente(newUser.Us) == null)
            {
                Utenti u = new Utenti()
                {
                    Username = newUser.Us,
                    Psw = newUser.Ps
                };
                _roomService.InsertUserIntoChatRoom(newUser.Us, new ObjectId("6632374d4a7668546ed7237e"));
                return _repo.Create(u);
            }
            return false;
        }

        public bool LoginUtente(UserLoginModel obj)
        {
            string md5Hash = MD5Helper.CalculateMD5(obj.Password);
            obj.Password = md5Hash;
            
            return _repo.CheckLogin(obj) is not null ? true : false;
        }

        public UtentiDto? GetUtente(string username)
        {
            Utenti? u = _repo.GetByUsername(username);
            if (u != null) {
                UtentiDto objDto = new UtentiDto()
                {
                    Us = u.Username,
                    Ps = u.Psw,
                    PI = u.ProfileImg,
                    MyChats = _roomService.GetRoomsByUser(username)

                };
                return objDto;
                
            }
            return null;
        }

        public List<UtentiDto>? GetAllUtenti()
        {
            List<UtentiDto> utentiDtos = new List<UtentiDto>();
            foreach(Utenti u in _repo.GetAll())
            {
                UtentiDto objDto = new UtentiDto()
                {
                    Us = u.Username,
                    Ps = u.Psw,
                    PI = u.ProfileImg,
                };
                utentiDtos.Add(objDto);
            }
            return utentiDtos;
        }
    }
}
