﻿using System.ComponentModel.DataAnnotations.Schema;

namespace StantreonApi.Models.Users;

public class Member : User
{
    public string DisplayName { get; set; }
}
