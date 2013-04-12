using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WenSharkGenNHibernate.EN.Default_;
using WenSharkGenNHibernate.CEN.Default_;
using System.Web.Security;
using Newtonsoft.Json.Linq;

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
            AppUserCEN appuserCEN = new AppUserCEN();
            if (appuserCEN.IsValid(user,pass))
            {
                AppUserEN userEN = appuserCEN.GetByUsername(user)[0];
                FormsAuthentication.SetAuthCookie(user, false);
                return this.Request.CreateResponse(HttpStatusCode.OK, userEN);
            }
            else
            {
                return this.Request.CreateResponse(HttpStatusCode.NotAcceptable);
            }

        }

        [Authorize]
        public HttpResponseMessage getlogout(string logout)
        {
            FormsAuthentication.SignOut();
            return this.Request.CreateResponse(HttpStatusCode.OK);
        }


        public HttpResponseMessage PostSignUpAppUser(JObject data)
        {
            AppUserCEN usrCEN = new AppUserCEN();
            String name = data["name"].ToString();
            String pass = data["passw"].ToString();
            String username = data["username"].ToString();
            String email = data["email"].ToString();

            if (name != null && pass != null && username != null && email != null)
            {
                if (!usrCEN.Exist(username))
                {
                    int id = usrCEN.New_(pass, name, username, email, DateTime.Now);
                    AppUserEN usr = new AppUserEN();
                    return this.Request.CreateResponse(HttpStatusCode.OK, id);
                }
                else
                {
                    return this.Request.CreateResponse(HttpStatusCode.Conflict, "Username ya existe.");
                }
            }
            else
            {
                return this.Request.CreateResponse(HttpStatusCode.BadRequest, "Error desconocido");
            }
            
        }

    }
}
