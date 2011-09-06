using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFSample.DAL.SqlRepository;
using EFSample.Model;
using System.Data.Entity;

namespace EFSample.DAL.Facotries
{
    public class RepositoryFactory
    {
        private DbContext _context;

        // Esto es solo para el ejemplo, realmente la creación de los reposutories se debe manejar con 
        // con el IoC container para poder manejar la vida de estos.
        public IRepository<T> CreateRepo<T>() where T : class
        {
            InitContext();

            Type t = typeof(T);
            if (typeof(T) == typeof(User))
                return (IRepository<T>)new EFUsersRepository(_context);

            throw new NotImplementedException("Tipo de respository no soportado");
        }

        private void InitContext()
        {
            if (_context == null)
                _context = new SampleDBContext();
        }

        public static void ConfigureDatabase()
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<SampleDBContext>());
        }
    }
}
