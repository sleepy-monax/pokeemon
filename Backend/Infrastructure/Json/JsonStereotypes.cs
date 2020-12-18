using System;
using System.Collections.Generic;
using System.IO;
using Model.Creature;
using Newtonsoft.Json;

namespace Infrastructure.Json
{
    public class JsonStereotypes
    {
        public static Stereotype get(Stereotype stereotype)
        {
            var jsonString = File.ReadAllText("Assets/creatures.json");
            List<Stereotype> stereotypes = JsonConvert.DeserializeObject<List<Stereotype>>(jsonString);
            Stereotype st = new Stereotype();
            foreach (var ster in stereotypes)
            {
                if (ster.Name.Equals(stereotype.Name))
                {
                    st = ster;
                }
            }
            return st;
        }
    }
}