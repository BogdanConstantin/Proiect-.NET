﻿namespace Models.Authentication
{
    public class UserInformationsDto : BaseDto
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Username { get; set; }
    }
}
