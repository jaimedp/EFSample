using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using EFSample.Model;

namespace EFSample.DAL.SqlRepository
{
    public class EFUsersRepository : EFRepositoryBase<User>
    {
        public EFUsersRepository(DbContext context)
            : base(context)
        {
        }

        public override User GetById(int id, params Expression<Func<User, object>>[] eagerLoad)
        {
            return GetAllQuery(eagerLoad).Where(a => a.Id == id).SingleOrDefault();
        }
    }
}
