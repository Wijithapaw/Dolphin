using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dolphin.Areas.AdminArea.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class _BaseController : Controller
    {

    }
}