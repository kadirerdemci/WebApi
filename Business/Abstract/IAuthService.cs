using Core.Utilities.Results;
using Core.Utilities.Security.JWT;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAuthService
    {

        IDataResult<Users> Register(Entities.DTOs.UserForRegisterDto userForRegisterDto, string password);
        IDataResult<Users> Login(Entities.DTOs.UserForLoginDto userForLoginDto);
        IResult UserExists(string email);
        IDataResult<AccesToken> CreateAccessToken(Users user);
    }
}
