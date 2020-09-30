using Microsoft.AspNet.Identity;
using SetList.Models;
using SetList.Models.Show;
using SetList.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SetList.WebMVC.Controllers
{
    [Authorize]
    public class ShowController : Controller
    {
        // GET: Show
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ShowService(userId);
            var model = service.GetShows();
            return View(model);
        }

    public ActionResult Create()
        {
            return View();
        }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(ShowCreate model)
        {
            if(!ModelState.IsValid)
            {
            return View(model);
            }

            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ShowService(userId);

            service.CreateShow(model);

            return RedirectToAction("Index");
        }
    }

}