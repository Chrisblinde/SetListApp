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
            var service = CreateBandService();
            
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
            if (!ModelState.IsValid) return View(model);
            var service = CreateBandService();
            if(service.CreateBand(model))
            {
                TempData["SaveResult"] = "Band Created!";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Sorry, Could Not Create Band!");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateBandService();
            var model = svc.GetBandById(id);

            return View(model);
        }

        public ActionResult Edit (int id)
        {
            var service = CreateBandService();
            var detail = service.GetBandById(id);
            var model =
                new BandEdit
                {
                    BandId = detail.BandId,
                    Name = detail.Name,
                    Members = detail.Members,
                    YearsActive = detail.YearsActive,
                    NumberOfAlbums = detail.NumberOfAlbums
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, BandEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if(model.BandId != id)
            {
                ModelState.AddModelError("", "Id Does Not Match!");
                return View(model);
            }

            var service = CreateBandService();

            if(service.UpdateBand(model))
            {
                TempData["SaveResult"] = "Band Updated!";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Could Not Update Band!");
            return View(model);
        }



        private BandService CreateBandService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new BandService(userId);
            return service;
        }
    }
}
