namespace EF_DB_Library
{
    //важно наличие поля Id, для создания первичного ключа в таблице в БД
    //по умолчанию при генерации БД EF в качестве первичных ключей будет рассматривать свойства с именами Id или [Имя_класса]Id (то есть UserId)
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Email { get; set; }
        public string Role { get; set; }
    }
}
