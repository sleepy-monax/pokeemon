using System;
using Model.Creature;
using Newtonsoft.Json.Linq;

namespace Model.Effets
{
    public static class EffectFactory
    {
        public static IEffect createFromJson(JObject json)
        {
            switch (json["type"]?.ToObject<string>() ?? "dummy")
            {
                case "alteration":
                    return new Alteration
                    {
                        Attack = json["attack"]?.ToObject<int>() ?? 1,
                        Defense = json["defense"]?.ToObject<int>() ?? 1,
                        Speed = json["speed"]?.ToObject<int>() ?? 1,
                        Health = json["health"]?.ToObject<int>() ?? 1
                    };

                case "change_type":
                    Enum.TryParse(json["new_type"]?.ToObject<string>() ?? "normal", out Types newType);

                    return new ChangeType
                    {
                        NewType = newType,
                    };

                case "regen":
                    return new Regen
                    {
                        Amount = json["amount"]?.ToObject<int>() ?? 10
                    };

                case "damage":
                    Enum.TryParse(json["damage"]?.ToObject<string>() ?? "normal", out Types damageType);

                    return new Damage
                    {
                        Amount = json["amount"]?.ToObject<int>() ?? 10,
                        Type = damageType
                    };

                default:
                    break;
            }

            return new Damage { Amount = 0, Type = Types.Normal };
        }
    }
}