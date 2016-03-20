using Dolphin.Areas.AdminArea.Models;
using Dolphin.Data;
using Dolphin.Domain;
using Dolphin.Domain.Entities;
using Dolphin.Domain.Services;
using Dolphin.Services;
using Dolphin.Utills;
using Microsoft.AspNet.Identity.Owin;
using MvcSiteMapProvider;
using MvcSiteMapProvider.Web.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dolphin.Areas.AdminArea.Controllers
{
    public class DonorController : _BaseController
    {
        private readonly IDonorService DonorService;

        public DonorController(IDonorService donorService)
        {
            this.DonorService = donorService;
        }

        public ActionResult Index()
        {
            var donors = DonorService.GetAll();
            return View(donors);
        }

        /* Test method: site map nodes with url parameters
        [SiteMapTitle("FirstName", Target = AttributeTarget.ParentNode)]
        public ActionResult MoreDetails(string adminId)
        {
            SiteMapHelper.SetParentRouteValues("id", adminId);

            var admin = DonorService.Get(adminId);
            return View(admin);
        }*/
    }
}
