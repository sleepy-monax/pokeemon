using System.Collections.Generic;
using System.IO;
using Model.Action;
using Model.Effets;
using Newtonsoft.Json.Linq;

namespace Infrastructure.Json
{
    public static class JsonAttacks
    {
        private static string ATTACKS_PATH = "Assets/attacks.json";

        private static Dictionary<string, Action> _actions;

        public static Action getByName(string name)
        {
            if (_actions == null)
            {
                _actions = new Dictionary<string, Action>();

                var actionsJson = JArray.Parse(File.ReadAllText(ATTACKS_PATH));

                foreach (var actionToken in actionsJson)
                {
                    if (actionToken is JObject actionObject)
                    {
                        Action action = new Action
                        {
                            Name = actionObject["name"].ToObject<string>(),
                            Description = actionObject["description"].ToObject<string>(),

                            Accuracy = actionObject["accuracy"].ToObject<int>(),
                            PowerPoint = actionObject["power_point"].ToObject<int>(),
                            Probability = actionObject["probability"].ToObject<int>(),

                            Effect = EffectFactory.createFromJson(actionObject["price"] as JObject)
                        };

                        _actions[action.Name] = action;
                    }
                }
            }

            return _actions["name"].Clone();
        }
    }
}