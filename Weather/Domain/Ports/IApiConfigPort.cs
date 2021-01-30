﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Weather.Domain.Ports
{
    interface IApiConfigPort
    {
        string Url { get; set; }
        string Key { get; set; }
    }
}