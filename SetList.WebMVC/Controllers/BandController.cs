using SetList.Models;
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
            var model = new BandListItem[0];
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
            if(!ModelState.IsValid)
            {

            }
            return View(model);
        }
    }
}