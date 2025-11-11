namespace VentasDemo.Models
{
    public class User
    {
        // Clase representando al usuario
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        public string FullName { get; set; }

        public string Role { get; set; }
    }
}