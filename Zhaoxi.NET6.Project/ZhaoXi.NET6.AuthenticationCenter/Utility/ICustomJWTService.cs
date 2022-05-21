using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZhaoXi.NET6.AuthenticationCenter.Utility
{
    public interface ICustomJWTService
    {
        string GetToken(string UserName, string password);
    }
}
