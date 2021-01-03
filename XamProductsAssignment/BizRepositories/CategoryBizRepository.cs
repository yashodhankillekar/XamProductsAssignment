using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XamProductsAssignment.Models;

namespace XamProductsAssignment.BizRepositories
{
    public class CategoryBizRepository : IBizRepository<Category, int>
    {
        RhealXamProductsDbContext ctx;

        public CategoryBizRepository()
        {
            ctx = new RhealXamProductsDbContext();
        }

        public Category Create(Category entity)
        {
            ctx.Categories.Add(entity);
            ctx.SaveChanges();
            return entity;
        }

        public bool Delete(int id)
        {
            Category temp = ctx.Categories.Find(id);
            if (temp != null)
            {
                ctx.Categories.Remove(temp);
                ctx.SaveChanges();
            }
            return true;
        }

        public List<Category> GetData()
        {
            return ctx.Categories.ToList();
        }

        public Category GetData(int id)
        {
            Category result = ctx.Categories.Find(id);
            return result;
        }

        public Category Update(int id, Category entity)
        {
            Category result = ctx.Categories.Find(id);
            if (result != null)
            {
                result.CategoryName = entity.CategoryName;
                ctx.SaveChanges();
                return result;
            }
            return entity;
        }
    }
}
