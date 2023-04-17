namespace API.DTOs
{
    public class UserDto
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
    }
}

// The Object that we will return to the user when he registers or logins

// Check using jwt.io
