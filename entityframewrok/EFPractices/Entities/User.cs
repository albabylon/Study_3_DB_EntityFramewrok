namespace EFPractices.Entities
{
    //важно наличие поля Id, для создания первичного ключа в таблице в БД
    //по умолчанию при генерации БД EF в качестве первичных ключей будет рассматривать свойства с именами Id или [Имя_класса]Id (то есть UserId)
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }

        // Внешний ключ
        public int CompanyId { get; set; }

        // Навигационное свойство
        public Company Company { get; set; }

        // Навигационное свойство
        //public UserCredential UserCredential { get; set; }

        // Навигационное свойство
        //public List<Topic> Topics { get; set; } = new List<Topic>();

        //Свойства CompanyId и Company в классе User, на самом деле, не являются обязательными
        //для создания связи между таблицами и могут быть опущены, пока в классе Company остается поле Users
        //Но явное указание данных свойств позволяет работать со связью объектов в обе стороны, поэтому советуем оставлять их.
    }
}
