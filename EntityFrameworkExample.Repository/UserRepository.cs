using EntityFrameworkExample.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkExample.Repository
{
    public class UserRepository : IUserDal
    {
        Context c = new Context();
        DbSet<Users> _object;

        public List<Users> List()
        {
            return _object.ToList();
        }

        public void Insert(Users p)
        {
            _object.Add(p);
            c.SaveChanges();
        }

        public void Update(Users p)
        {
            c.SaveChanges();
        }

        public void Delete(Users p)
        {
            _object.Remove(p);
            c.SaveChanges();
        }

        public List<Users> List(Expression<Func<Users, bool>> filter)
        {
            return _object.Where(filter).ToList();
        }

        public Users Get(Expression<Func<Users, bool>> filter)
        {
            return _object.SingleOrDefault(filter);
        }
    }
}
