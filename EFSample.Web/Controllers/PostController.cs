using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EFSample.Model;
using EFSample.Web.Models;
using EFSample.DAL.Facotries;
using EFSample.DAL;
using EFSample.Web.ViewModels;

namespace EFSample.Web.Controllers
{   
    public class PostController : Controller
    {
        private readonly IRepository<User> _userRepository;

		// If you are using Dependency Injection, you can delete the following constructor
        public PostController() 
        {
            var factory = new RepositoryFactory();
            _userRepository = factory.CreateRepo<User>();
        }

        public PostController(IRepository<User> postRepository)
        {
			_userRepository = postRepository;
        }

        //
        // GET: /Post/

        public ViewResult Index(int userId)
        {
            ViewBag.UserId = userId;
            return View(GetUserPosts(userId));
        }

        //
        // GET: /Post/Create

        public ActionResult Create(int id)
        {
            ViewBag.UserId = id;
            return View();
        } 

        //
        // POST: /Post/Create

        [HttpPost]
        public ActionResult Create(int userId, PostViewModel postVM)
        {
            if (ModelState.IsValid)
            {
                User u = _userRepository.GetById(userId);
                var post = new Post() { PostDate = DateTime.Today, Text = postVM.Text };
                u.Posts.Add(post);
                _userRepository.Save();
                return RedirectToAction("Index", new { userId = u.Id });
            }
            else
            {
                return View();
            }
        }

       
        private ICollection<Post> GetUserPosts(int userId)
        {
            return _userRepository.GetById(userId, x => x.Posts).Posts;
        }
    }
}

