using Model.Shared;

namespace Model.User
{
    public interface IUser : IEntity
    {
        bool Administrator { get; set; }
        string Pseudo { get; set; }
        string Email { get; set; }
        string Password { get; set; }
        int Money { get; set; }
    }
}