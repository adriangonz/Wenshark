using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WenSharkApp.Controllers
{
    public class IndexController : Controller
    {
        //
        // GET: /Index/

        public ActionResult Index()
        {
            //return Redirect(Url.Content("/Assets/index2.html"));
            Server.Transfer("/Assets/index.html", true);

            return null;
        }

    }
}
