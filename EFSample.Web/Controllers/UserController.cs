using System.Web.Mvc;
using EFSample.DAL;
using EFSample.DAL.Facotries;
using EFSample.Model;

namespace EFSample.Web.Controllers
{   
    public class UserController : Controller
    {
		private readonly IRepository<User> _userRepository;

		// If you are using Dependency Injection, you can delete the following constructor
        public UserController() 
        {
            var factory = new RepositoryFactory();
            _userRepository = factory.CreateRepo<User>();
        }

        public UserController(IRepository<User> userRepository)
        {
			_userRepository = userRepository;
        }

        //
        // GET: /User/

        public ViewResult Index()
        {
            return View(_userRepository.GetAll());
        }

        //
        // GET: /User/Details/5

        public ViewResult Details(int id)
        {
            return View(_userRepository.GetById(id,x=>x.Posts));
        }

        //
        // GET: /User/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /User/Create

        [HttpPost]
        public ActionResult Create(User user)
        {
            if (ModelState.IsValid) {
                _userRepository.Add(user);
                _userRepository.Save();
                return RedirectToAction("Index");
            } else {
				return View();
			}
        }
        
        //
        // GET: /User/Edit/5
 
        public ActionResult Edit(int id)
        {
             return View(_userRepository.GetById(id));
        }

        //
        // POST: /User/Edit/5

        [HttpPost]
        public ActionResult Edit(User user)
        {
            if (ModelState.IsValid) {
                _userRepository.Update(user);
                _userRepository.Save();
                return RedirectToAction("Index");
            } else {
				return View();
			}
        }

        //
        // GET: /User/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View(_userRepository.GetById(id));
        }

        //
        // POST: /User/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            _userRepository.Delete(id);
            _userRepository.Save();

            return RedirectToAction("Index");
        }
    }
}

