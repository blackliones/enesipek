using Business.Abstract;
using Business.Contants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        private IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }
        IDataResult<Product> IProductService.GetById(int productId)
        {
            //try catch ile hatalar kontrol edilebilir
            return new SuccessDataResult<Product>(_productDal.Get(filter: p => p.ProductId == productId));
        }

        IDataResult<List<Product>> IProductService.GetList()
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetList().ToList());
        }

        IDataResult<List<Product>> IProductService.GetListByCategory(int categoryId)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetList(filter: p => p.CategoryId == categoryId).ToList());
        }
        //Mesajlar düzenlenebilir
        public IResult Add(Product product)
        {
            //Business code-Daha önce eklenen bir ürün tekrar eklenememesi için bir kod yazabilirsin
            _productDal.Add(product);
            return new SuccessResult(Messages.ProductAdded);
        }

        public IResult Delete(Product product)
        {
            _productDal.Delete(product);
            return new SuccessResult(Messages.ProductDeleted);
        }

        public IResult Update(Product product)
        {
            _productDal.Update(product);
            return new SuccessResult(Messages.ProductUpdated);
        }
    }
}
