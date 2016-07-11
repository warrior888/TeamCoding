﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamCoding.SourceControl
{
    public class MachineIdentityProvider : IIdentityProvider
    {
        public string GetIdentity()
        {
            return Environment.UserName;
        }
    }
}
