using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Result;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IProductService
    {
        IDataResult<List<Product> >GetAll();
        IDataResult< List<Product>> GetAllByCategoryId(int categoryId);

        IDataResult < Product> GetById(int productId);

        IResult Add(Product product);

        IResult Update(Product product);

        IResult Delete(Product product);

        IDataResult<List<Product>> GetAllByUnitPrice(decimal min, decimal max);







    }
}
