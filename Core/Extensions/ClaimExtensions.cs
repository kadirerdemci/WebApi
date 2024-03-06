using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Core.Extensions
{

    //bu sınıfta bizim claims sınıfında olmayan methodları ekledik Aşağıdaki kodları incelersek...
    public static class ClaimExtensions
    {
        //(this ICollection<Claim> claims,string email) yazan yerde Claim sınıfına AddEmail
        //methodunu ekle diyoruz. 
        public static void AddEmail(this ICollection<Claim> claims, string email)
        {
            //Daha sonra aşağıdaki methodla ekleme yaparız ...Diğer kodlarda aynı mantık
            claims.Add(new Claim(JwtRegisteredClaimNames.Email, email));
        }

        public static void AddName(this ICollection<Claim> claims, string name)
        {
            claims.Add(new Claim(ClaimTypes.Name, name));
        }

        public static void AddNameIdentifier(this ICollection<Claim> claims, string nameIdentifier)
        {
            claims.Add(new Claim(ClaimTypes.NameIdentifier, nameIdentifier));
        }

        public static void AddRoles(this ICollection<Claim> claims, string[] roles)
        {
            roles.ToList().ForEach(role => claims.Add(new Claim(ClaimTypes.Role, role)));
        }
    }
}
