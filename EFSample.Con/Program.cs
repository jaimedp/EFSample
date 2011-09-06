using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFSample.Model;
using EFSample.DAL;
using EFSample.DAL.SqlRepository;
using EFSample.DAL.Facotries;

namespace EFSample.Con
{
    class Program
    {
        static void Main(string[] args)
        {
            var repo = GetUserRepo();

            int id = PrintAllUsers(repo);

            var repo2 = GetUserRepo();

            var u2 = repo2.GetById(id);
            u2.FirstName = "Alberto";
            repo2.Update(u2);
            repo2.Save();

//            repo2.Delete(2);

            /*
            var u = new User() { FirstName = "Jorge", LastName = "Perez", Email = "juan@perez.com" };
            repo.Add(u);
            repo.Save();

             */
            
            PrintAllUsers(repo);

            Console.ReadKey();
        }

        private static IRepository<User> GetUserRepo()
        {
            RepositoryFactory factory = new RepositoryFactory();
            return factory.CreateRepo<User>();
        }

        private static int PrintAllUsers(IRepository<User> repo)
        {
            Console.WriteLine("--------");
            var users = repo.GetAll();
            var id = users.First().Id;
            foreach (var u in users)
                Console.WriteLine(string.Format("ID: {0} - {1}", u.Id, u));

            return id;
        }
    }
}
