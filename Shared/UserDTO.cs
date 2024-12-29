namespace Domain.Entities
{
    public class UserDTO
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public required string Phone { get; set; }
        public string? Address { get; set; }
        public int RoleId { get; set; }
        public string? RoleName { get; set; }
    }
}
