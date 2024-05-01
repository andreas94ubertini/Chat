﻿namespace ChatApi.Models
{
    public class UserLoginModel
    {
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string? UserType { get; set; } = "USER";
    }
}
