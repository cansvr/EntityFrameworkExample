using EntityFrameworkExample.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkExample.Repository
{
    public class EfUserDal : GenericRepository<Users>, IUserDal
    {

    }
}
