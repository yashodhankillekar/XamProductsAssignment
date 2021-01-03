using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XamProductsAssignment.Models;

namespace XamProductsAssignment.BizRepositories
{
    public class UserBizRepository : IBizRepository<User, int>
    {
        RhealXamProductsDbContext ctx;

        public UserBizRepository()
        {
            ctx = new RhealXamProductsDbContext();
        }

        public User Create(User entity)
        {
            ctx.Users.Add(entity);
            ctx.SaveChanges();
            return entity;
        }

        public bool Delete(int id)
        {
            User temp = ctx.Users.Find(id);
            if (temp != null)
            {
                ctx.Users.Remove(temp);
                ctx.SaveChanges();
            }
            return true;
        }

        public List<User> GetData()
        {
            return ctx.Users.ToList();
        }

        public User GetData(int id)
        {
            User result = ctx.Users.Find(id);
            return result;
        }

        public User Update(int id, User entity)
        {
            User result = ctx.Users.Find(id);
            if (result != null)
            {
                result.UserName = entity.UserName;
                result.UserPassword = entity.UserPassword;
                ctx.SaveChanges();
                return result;
            }
            return entity;
        }

    }
}
