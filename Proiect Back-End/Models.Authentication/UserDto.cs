﻿namespace Models.Authentication
{
    public class UserDto : BaseDto
    { 
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }
    }
}
