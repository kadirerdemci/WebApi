using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Bussines
{
    public class BusinessRules
    {


        //params ile IResult turunde virgulle ayirarak istediginiz kadar parametre ekleyebilirsiniz demek
        public static IResult Run(params IResult[] logics)  //>>>> logic burada kural demek
        {
            foreach (var logic in logics)   //butun kurallari gez 
            {
                if (!logic.Succes)        //kurala uymayan varsa, (basarisiz olan varsa su logic hatali diyoruz)
                {
                    return logic;          //o uymayan kurali dondur
                }
            }

            return null;      //basariliysa hicbirsey dondurmesine gerek yok

        }
    }
}
