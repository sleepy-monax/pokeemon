namespace Model.User
{
    public class User : IUser
    {
        public int Id { get; set; }
        public bool Administrator { get; set; }
        public string Pseudo { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int Money { get; set; }

        public User() {}

        public User(int id, string pseudo, string email, string password)
        {
            Id = id;
            Pseudo = pseudo;
            Email = email;
            Password = password;
            Administrator = false;
            Money = 120;
        }

        public User(int id, bool administrator, string pseudo, string email, string password, int money)
        {
            Id = id;
            Administrator = administrator;
            Pseudo = pseudo;
            Email = email;
            Password = password;
            Money = money;
        }

        public User(string pseudo, string email)
        {
            Id = 0;
            Pseudo = pseudo;
            Email = email;
        }

        public User(User user)
        {
            Administrator = false;
            Password = user.Password;
            Pseudo = user.Pseudo;
            Money = 120;
            Email = user.Email;
        }
    }
}
