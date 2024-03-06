using Core.Utilities.Results;
using FluentValidation;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using ValidationException = FluentValidation.ValidationException;

namespace Core.CrossCuttingConcerns.Validation
{
    public static class ValidationTool
    {

        public static void Validate(IValidator validator,object entity)
        {
            //Validation contexti oluşturur ve hangi tipte çalışılacaksa eğer onun için yazılır
            var validContext = new ValidationContext<object>(entity);


            //Bizim kendi oluşturduğumuz validator sınıfını çağırıp bir nesne oluşturduk
            //Aşağıdaki kodu iptal etmemizin nedeni IValidator yani CarValidatorun üst sınıfı olan 
            //interfaceyi CarValidatorunda referansını tutan değişkeni verddik o yüzden ona gerek kalmadı
            /////////////7CarValidator carValidator = new CarValidator();

            //daha sonra olştrduğumz nesnenin validate methodunu çağırıp contexi içine atıp kontrolü sağladık
            //Gelen kontrol bilgilerini ise result içine attık
            var result = validator.Validate(validContext);

            //Burada if ile kontrol ettik result valid mi true gelirse çalışır zaten
            //Ama valid değilse ve false gönderirse direk validationException atar.
            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }
        }



     

    }
}
