using System;
using System.Collections.Generic;

namespace ChatApi.Models;

public partial class Utenti
{
    public int UserId { get; set; }

    public string? Codice { get; set; } = Guid.NewGuid().ToString().ToUpper();

    public string Username { get; set; } = null!;

    public string Psw { get; set; } = null!;

    public string? ProfileImg { get; set; }

    public bool? IsDeleted { get; set; } = false;

    public string? UserType { get; set; } = "USER";
}
