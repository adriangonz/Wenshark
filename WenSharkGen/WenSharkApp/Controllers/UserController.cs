using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WenSharkGenNHibernate.EN.Default_;
using WenSharkGenNHibernate.CEN.Default_;
using System.Web.Security;


namespace WenSharkApp.Controllers
{
    public class UserController : ApiController
    {
        [Authorize]
        public String get()
        {
            return "Hola usuario registardo";
        }

        [Authorize]
        public HttpResponseMessage get(int id)
        {
            UserEN user;
            UserCEN userCEN = new UserCEN();

            user = userCEN.GetByID(id);

            return this.Request.CreateResponse(HttpStatusCode.OK, user);
        }

        /// <summary>
        /// Este controlador se encarga de logear los usuarios registrados de nuestra aplicación
        /// hay que ver como realizar el login de OAuth y demás
        /// </summary>
        /// <param name="user">Nombre de usuario</param>
        /// <param name="pass">Contraseña</param>
        /// <returns>Información del usuario {id,nombre,image}</returns>
        public HttpResponseMessage getlogin(string user, string pass)
        {
            if (user == "pepe" && pass == "pepe")
            {
                FormsAuthentication.SetAuthCookie("pepe", false);
                
                return this.Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return this.Request.CreateResponse(HttpStatusCode.Unauthorized);
            }

        }

        [Authorize]
        public HttpResponseMessage getlogout(string logout)
        {
            FormsAuthentication.SignOut();
            return this.Request.CreateResponse(HttpStatusCode.OK);
        }

    }
}
