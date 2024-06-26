﻿using ChatApi.DTO;
using ChatApi.Filter;
using ChatApi.Models;
using ChatApi.Repos;
using ChatApi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;
using System.Security.Cryptography;

namespace ChatApi.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class UtentiController : Controller
    {
        #region Injection
        private readonly UserService _service;

        public UtentiController(UserService service)
        {
            _service = service;
        }
        #endregion
        [HttpPost("Register")]
        public IActionResult RegisterUser([FromBody]UtentiDto newUser)
        {
            
            string md5Hash = MD5Helper.CalculateMD5(newUser.Ps);
            newUser.Ps = md5Hash;
            if (_service.Create(newUser))
            {
                return Ok(new Risposta()
                {
                    Status="Success"
                });
            }

            return Ok(new Risposta()
            {
                Status = "Errore durante la registrazione"
            });
        }

        [HttpGet("profiloutente")]
        [AuthorizeUserType("USER")]
        public IActionResult ProfiloUtente()
        {

            var nickname = User.Claims.FirstOrDefault(x => x.Type == "Username")?.Value;
            if (nickname != null)
            {
                return Ok(new Risposta()
                {
                    Status = "SUCCESS",
                    Data = _service.GetUtente(nickname)
                });
            }
            return Ok(new Risposta()
            {
                Status = "Error"
                
            });
        }

        [HttpPut("modificaImg")]
        [AuthorizeUserType("USER")]
        public IActionResult ModifyProfileImg(UtentiDto userDto) {

            if (_service.UpdateProfileImg(userDto))
                return Ok(new Risposta()
                {
                    Status = "Success"
                });
            return Ok(new Risposta()
            {
                Status = "Errore"
            });
        }

        [HttpGet("AllUsers")]
        public IActionResult GetAllUsers()
        {
            return Ok(new Risposta()
            {
                Status = "Success",
                Data = _service.GetAllUtenti()
            }) ;
        }

    }
}
