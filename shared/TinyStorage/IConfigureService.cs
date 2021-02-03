using System;
using System.Collections.Generic;
using System.Text;

namespace TinyStorage
{
    public interface IConfigurationService
    {
        /// <summary>
        /// Can only add value with key once.
        /// </summary>
        /// <param name="key">The key of the config value.</param>
        /// <param name="value">The value of the config value.</param>
        void Add(string key, string value);

        string this[string key] { get; }
    }
}
