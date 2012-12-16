using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AH.Core.Services;
using AH.Business.Models;

namespace AH.Business.UI.Controllers
{
    public class HomeController : Controller
    {
        private IRepository repository;

        public HomeController(IRepository repository)
        {
            this.repository = repository;
        }
        //
        // GET: /Home/

        public ActionResult Index()
        {
            bool ext=repository.Query<SiteProfile>()
                .FirstOrDefault(x => x.ProfileKey.Equals("sitename")) == null ?
                true : false;
            if (ext)
            {
                SiteProfile sp = new SiteProfile();
                sp.ProfileKey = "sitename";
                sp.ProfileValue = "AH企业建站";
                repository.Insert(sp);
            }
            return View();
        }

    }
}
