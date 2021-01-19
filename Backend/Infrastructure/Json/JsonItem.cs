using System.Collections.Generic;
using System.IO;
using Model.Effets;
using Model.Item;
using Newtonsoft.Json.Linq;

namespace Infrastructure.Json
{
    public static class JsonItem
    {
        private static readonly string ITEMS_PATH = "Assets/items.json";

        private static Dictionary<string, Item>? _items;

        public static Item GetByName(string name)
        {
            if (_items == null)
            {
                _items = new Dictionary<string, Item>();

                var itemsJson = JArray.Parse(File.ReadAllText(ITEMS_PATH));

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