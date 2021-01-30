using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Weather.Domain.Ports;

namespace Weather.Domain.Services
{
    public class ApiConfigService : IApiConfigPort
    {
        public string Url { get; set; }
        public string Key { get; set; }

        public ApiConfigService(string _url, string _key)
        {
            Url = _url;
            Key = _key;
        }
    }
}
