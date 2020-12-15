namespace Model.UserItems
{
    public class UserItem : IUserItems
    {
        public int Id { get; set; }
        public int IdUser { get; set; }
        public string NameItem { get; set; }
        public int Quantity { get; set; }

        public UserItem()
        {
        }

        public UserItem(int id, int idUser, string nameItem, int quantity)
        {
            Id = id;
            IdUser = idUser;
            NameItem = nameItem;
            Quantity = quantity;
        }
    }
}