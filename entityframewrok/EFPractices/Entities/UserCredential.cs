namespace EFPractices.Entities
{
    public class UserCredential
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        // Внешний ключ
        public int UserId { get; set; }

        // Навигационное свойство
        public User User { get; set; }

    }
}
