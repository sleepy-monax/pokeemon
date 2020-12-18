using System.Collections.Generic;
using System.IO;
using Model.Effets;
using Model.Item;
using Newtonsoft.Json.Linq;

namespace Infrastructure.Json
{
    public class JsonItem
    {
        private Dictionary<string, Item> _items;

        private static string ITEMS_PATH = "Assets/items.json";

        public Item getByName(string name)
        {
            if (_items == null)
            {
                var itemsJson = JArray.Parse(File.ReadAllText(ITEMS_PATH));

                _items = new Dictionary<string, Item>();

                foreach (var itemToken in itemsJson)
                {
                    if (itemToken is JObject itemObject)
                    {
                        Item item = new Item
                        {
                            Name = itemObject["name"].ToObject<string>(),
                            Description = itemObject["description"].ToObject<string>(),
                            Price = itemObject["price"].ToObject<int>(),
                            Effect = EffectFactory.createFromJson(itemObject["price"] as JObject)
                        };

                        _items[item.Name] = item;
                    }
                }
            }

            return _items[name];
        }
    }
}