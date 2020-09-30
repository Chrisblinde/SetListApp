using Microsoft.AspNet.Identity;
using SetList.Models;
using SetList.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SetList.WebMVC.Controllers
{
    [Authorize]
    public class BandController : Controller
    {
        // GET: Band
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new BandService(userId);
            var model = service.GetBands();

            return View(model);
        }

    public ActionResult Create()
        {
            return View();
        }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(BandCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            BandService service = CreateBandService();

            service.CreateBand(model);

            return RedirectToAction("Index");


        }

        private BandService CreateBandService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new BandService(userId);
            return service;
        }
    }
}
