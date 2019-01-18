namespace Models.Authentication
{
    public class UserAuthenticationDto : BaseDto
    {
        public string Username { get; set; }

        public string Password { get; set; }
    }
}
