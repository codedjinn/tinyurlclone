using System;
using System.Collections.Generic;
using System.Text;

namespace TinyStorage
{
    public class ConfigurationService : IConfigurationService
    {
        private Dictionary<string, string> _items;

        public ConfigurationService()
        {
            _items = new Dictionary<string, string>();
        }

        // should throw exception if key isn't there
        public string this[string key] => _items[key];

        public void Add(string key, string value)
        {
            if (!_items.ContainsKey(key))
            {
                _items.Add(key, value);
            }
        }
    }
}
