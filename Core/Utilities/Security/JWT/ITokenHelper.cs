using Core.Entities.Concretes;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.JWT
{
    public interface ITokenHelper
    {

        AccesToken CreateToken(Users user, List<OperationClaim> operationClaims);
      
    }
}
