using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.Encryption
{


    //Hatırlarsanız Web api projesinde application.json dosyası var oraya Security Key girmiştik
    // o stringi burada biz byte code haline dönüştürüyoruz.
    public class SecurityKeyHelper
    {

        
        
        public static SecurityKey CreateSecurityKey(string securityKey)
        {
            //burada gelen security keyi alıp byte code çevirip onu SymetricSecurtyKey tipine dönüştürüyor
           
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));
        }


    }
}
