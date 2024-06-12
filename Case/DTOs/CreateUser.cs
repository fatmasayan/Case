﻿namespace Case.DTOs;

public class CreateUser
{
    //[Required(ErrorMessage = "Boş bırakılamaz")]
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public DateTime BirthDate { get; set; }
}
