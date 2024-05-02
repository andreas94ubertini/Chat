﻿using ChatApi.DTO;
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
        private readonly RoomRepo _roomRepo;

        public UserService(UserRepo repository, RoomRepo roomRepo)
        {
            _repo = repository;
            _roomRepo = roomRepo;
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
                _roomRepo.InsertUserIntoChatRoom(newUser.Us, new ObjectId("6632374d4a7668546ed7237e"));
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
                    MyChats = _roomRepo.GetRoomByUser(username)

                };
                return objDto;
                
            }
            return null;
        }
    }
}
