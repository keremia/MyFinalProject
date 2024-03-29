﻿using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concreate;
using Entities.DTOs;
using System.Linq;
using System.Collections.Generic;

namespace DataAccess.Concreate.EntitiyFramework
{
    public class EfProductDal : EfEntityRepositoryBase<Product, NorthwindContext>, IProductDal
    {
        public List<ProductDetailDto> GetProductDetails()
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var result = from p in context.Products
                             join c in context.Categories
                             on p.CategoryId equals c.CategoryId
                             select new ProductDetailDto
                             {
                                 ProductId = p.ProductId, ProductName = p.ProductName , UnitPrice = p.UnitPrice,
                                 CategoryName = c.CategoryName, UnitsInStock = p.UnitsInStock,
                             };    
                return result.ToList();
            }
        }
    }
}
