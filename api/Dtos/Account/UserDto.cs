namespace api.Dtos.Account
{
    public class UserDto
    {
        public required string Id { get; set; }
        public required string UserName { get; set; }
        public required string Email { get; set; }
        public required string PhoneNumber { get; set; }
        public required string Role { get; set; }
    }
}
