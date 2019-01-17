using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Authentication
{
    public class UserAuthenticationDto : BaseDto
    {
        public string Username { get; set; }

        public string Password { get; set; }
    }
}
