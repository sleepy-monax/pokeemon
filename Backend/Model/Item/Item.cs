using Model.Effets;

namespace Model.Item
{
    public class Item
    {
        public string Name {get; set;}
        public string Description {get; set;}
        public int Price {get; set;}
        public IEffect Effect {get; set;}
    }
}