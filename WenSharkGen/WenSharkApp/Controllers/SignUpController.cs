using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WenSharkGenNHibernate.CEN.Default_;

namespace WenSharkApp.Controllers
{
    public class SignUpController : ApiController
    {

        public AppUserCEN PostSignup(JObject data)
        {
            
            AppUserCEN usr = new AppUserCEN();

            usr.New_(data["passw"].ToString(), data["name"].ToString(), data["username"].ToString(), 
                data["email"].ToString(), DateTime.Now);
            return usr;
        }
    }
}
