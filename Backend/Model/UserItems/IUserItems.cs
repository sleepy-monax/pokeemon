using Model.Shared;

namespace Model.UserItems
{
    public interface IUserItems : IEntity
    {
        int IdUser { get; set; }
        string NameItem { get; set; }
        int Quantity { get; set; }
        
    }
}