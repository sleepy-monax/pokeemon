using System.Collections.Generic;
using System.IO;
using Model.Attacks;
using Model.Effets;
using Newtonsoft.Json.Linq;

namespace Infrastructure.Json
{
    public static class JsonAttacks
    {
        private static readonly string ATTACKS_PATH = "Assets/attacks.json";

        private static Dictionary<string, Attack>? _actions ;

        public static Attack GetByName(string name)
        {
            if (_actions == null)
            {
                _actions = new Dictionary<string, Attack>();

                var actionsJson = JArray.Parse(File.ReadAllText(ATTACKS_PATH));

                foreach (var actionToken in actionsJson)
                {
                    if (!(actionToken is JObject actionObject)) continue;
                    
                    Attack attack = new Attack
                    {
                        Name = actionObject["name"].ToObject<string>(),
                        Description = actionObject["description"].ToObject<string>(),

                        Accuracy = actionObject["accuracy"].ToObject<int>(),
                        PowerPoint = actionObject["power_point"].ToObject<int>(),
                        Probability = actionObject["probability"].ToObject<int>(),

                        Effect = EffectFactory.createFromJson(actionObject["effect"] as JObject)
                    };

                    _actions[attack.Name] = attack;
                }
            }

            return _actions[name].Clone();
        }
    }
}