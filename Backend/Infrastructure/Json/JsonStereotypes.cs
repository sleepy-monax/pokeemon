using System;
using System.Collections.Generic;
using System.IO;
using Model.Attacks;
using Model.Creature;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;

namespace Infrastructure.Json
{
    public class JsonStereotypes
    {
        private static readonly string STEREOTYPES_PATH = "Assets/creatures.json";
        private static Dictionary<string, Stereotype>? _stereotypes;

        public static Stereotype GetByName(string name)
        {
            if (_stereotypes == null)
            {
                _stereotypes = new Dictionary<string, Stereotype>();
                
                var sterotypesJson = JArray.Parse(File.ReadAllText(STEREOTYPES_PATH));

                foreach (var stereotypeToken in sterotypesJson)
                {
                    if (stereotypeToken is JObject stereotypeObject)
                    {                        
                        Stereotype stereotype = new Stereotype()
                        {
                            Name = stereotypeObject["name"].ToObject<string>(),
                            Stats = stereotypeObject["stats"].ToObject<Stats>(),
                            Actions = new List<UnLockableAction>(),
                        };

                        _stereotypes[stereotype.Name] = stereotype;
                    }
                }
            }

            return _stereotypes[name];
        }
    }
}