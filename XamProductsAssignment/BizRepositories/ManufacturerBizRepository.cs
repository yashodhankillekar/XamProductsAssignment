using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XamProductsAssignment.Models;

namespace XamProductsAssignment.BizRepositories
{

    public class ManufacturerBizRepository : IBizRepository<Manufacturer, int>
    {
        RhealXamProductsDbContext ctx;

        public ManufacturerBizRepository()
        {
            ctx = new RhealXamProductsDbContext();
        }

        public Manufacturer Create(Manufacturer entity)
        {
            ctx.Manufacturers.Add(entity);
            ctx.SaveChanges();
            return entity;
        }

        public bool Delete(int id)
        {
            Manufacturer temp = ctx.Manufacturers.Find(id);
            if (temp != null)
            {
                ctx.Manufacturers.Remove(temp);
                ctx.SaveChanges();
            }
            return true;
        }

        public List<Manufacturer> GetData()
        {
            return ctx.Manufacturers.ToList();
        }

        public Manufacturer GetData(int id)
        {
            Manufacturer result = ctx.Manufacturers.Find(id);
            return result;
        }

        public Manufacturer Update(int id, Manufacturer entity)
        {
            Manufacturer result = ctx.Manufacturers.Find(id);
            if (result != null)
            {
                result.ManufacturerName = entity.ManufacturerName;
                ctx.SaveChanges();
                return result;
            }
            return entity;
        }
    }
}
