using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace GetSimple.WebAPI.Seguranca
{
    public class SigningConfigurations
    {
        private readonly string secret = "GetSimple_WebAPI_!195080@!";
        public SecurityKey Key { get; }
        public SigningCredentials SigningCredentials { get; }
        public SigningConfigurations()
        {
            var keyByteArray = Encoding.ASCII.GetBytes(secret);
            Key = new SymmetricSecurityKey(keyByteArray);
            SigningCredentials = new SigningCredentials(
                Key,
                SecurityAlgorithms.HmacSha256
                );
        }

    }
}
