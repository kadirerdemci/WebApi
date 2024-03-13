using System;
using System.Collections.Generic;
using Business.Abstract;
using Business.Contants;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        private readonly IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public IResult Add(Product product)
        {
            _productDal.Add(product);
            return new SuccesDataResult<Product>(product, Messages.ProductAdded);
        }

        public IResult Delete(Product product)
        {
            _productDal.Delete(product);
            if (product != null)
            {
                return new SuccesDataResult<Product>(product, Messages.ProductDeleted);
            }
            return new ErrorDataResult<Product>(product, Messages.ProductNotFound);

        }

        public IDataResult<List<Product>> GetAll()
        {
            return new SuccesDataResult<List<Product>>(_productDal.GetList(), Messages.ProductList);
        }

        public IDataResult<List<Product>> GetAllByCategoryId(int categoryId)
        {

            return new SuccesDataResult<List<Product>>(_productDal.GetList(p => p.CategoryId == categoryId), Messages.ProductList);

        }

        public IDataResult<List<Product>> GetAllByUnitPrice(decimal min, decimal max)
        {

            return new SuccesDataResult<List<Product>>(_productDal.GetList(p => p.UnitPrice >= min && p.UnitPrice <= max), Messages.ProductList);
        }

        public IDataResult<Product> GetById(int productId)
        {
            return new SuccesDataResult<Product>(_productDal.Get(p => p.ProductId == productId), Messages.ProductList);
        }

  

        public IResult Update(Product product)
        {

            _productDal.Update(product);
            return new SuccesDataResult<Product>(product, Messages.ProductUpdated);
        }
    }
}
