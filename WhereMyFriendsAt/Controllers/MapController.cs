using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WhereMyFriendsAt.Controllers
{
    public class MapController : Controller
    {
        public ActionResult MapTest()
        {
            return View("Map1");
        }
    }
}
