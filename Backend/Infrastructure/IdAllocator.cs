using System;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure
{
    public class IdAllocator
    {
        public string Prefix { get;  }

        private List<string> _used = new List<string>();
        private List<string> _available = new List<string>();
        private Random _random = new Random();
        
        public IdAllocator(string prefix)
        {
            Prefix = prefix;
        }

        string Generate()
        {
            var name = "";

            do
            {
                var randomNumber = _random.Next(1, int.MaxValue);
                name = $"{Prefix}-{randomNumber:X}";
            } while (_used.Contains(name));

            return name;
        }

        public string Alloc()
        {
            string id = "";
            
            if (_available.Any())
            {
                 id = _available.Last();
                _available.Remove(id);

                return id;
            }

             id = Generate();
            _used.Add(id);
            
            return id;
        }

        public void Free(string id)
        {
            _used.Remove(id);
            _available.Add(id);
        }
    }
}