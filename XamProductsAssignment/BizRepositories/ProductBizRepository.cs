using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XamProductsAssignment.Models;

namespace XamProductsAssignment.BizRepositories
{
    public class ProductBizRepository : IBizRepository<Product, int>
    {
        RhealXamProductsDbContext ctx;


        public ProductBizRepository()
        {
            ctx = new RhealXamProductsDbContext();
        }

        public Product Create(Product entity)
        {
            ctx.Products.Add(entity);
            ctx.SaveChanges();
            return entity;
        }

        public bool Delete(int id)
        {
            Product temp = ctx.Products.Find(id);
            if (temp != null)
            {
                ctx.Products.Remove(temp);
                ctx.SaveChanges();
            }
            return true;
        }

        public List<Product> GetData()
        {
            return ctx.Products.ToList();
        }

        public Product GetData(int id)
        {
            Product result = ctx.Products.Find(id);
            return result;
        }

        public Product Update(int id, Product entity)
        {
            Product result = ctx.Products.Find(id);
            if (result != null)
            {
                result.ProductId = entity.ProductId;
                result.ProductManufacturer = entity.ProductManufacturer;
                result.ProductCategory = entity.ProductCategory;
                result.ProductDescription = entity.ProductDescription;
                result.ProductPrice = entity.ProductPrice;
                result.ProductName = entity.ProductName;
                ctx.SaveChanges();
                return result;
            }
            return entity;
        }

    }
}
