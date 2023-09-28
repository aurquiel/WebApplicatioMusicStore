using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiTestUnitTesting.MockDependicies
{
    internal class ConfigurationDummy : IConfiguration
    {
        private Dictionary<string, string> _dictionary = new Dictionary<string, string>
        {
            { "Jwt:Key" , "_iX3exM_3IoxUQMin84eimfCFHq27cKkycX0-ajktkVP" },
            { "Jwt:Issuer" , "grupototal" },
            { "Jwt:Audience" , "localhost" },
        };


        public string this[string key] { get => _dictionary[key]; set => _dictionary[key] = value; }

        public IEnumerable<IConfigurationSection> GetChildren()
        {
            throw new NotImplementedException();
        }

        public IChangeToken GetReloadToken()
        {
            throw new NotImplementedException();
        }

        public IConfigurationSection GetSection(string key)
        {
            throw new NotImplementedException();
        }
    }
}
