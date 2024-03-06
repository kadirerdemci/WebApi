using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.Encryption
{
    public class SigningCredentialsHelper
    {

        public static SigningCredentials CreateSigningCredentials(SecurityKey securityKey) {

            //burada ise diyoruz ki senin anahtarın SecurityKey tipindeki securityKey
            //Algoritman ise 512Singature 
            return new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512Signature);
        
        }
    }
}
