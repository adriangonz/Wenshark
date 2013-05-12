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
using System.Net.Http.Headers;
using System.Threading.Tasks;
using WenSharkCP.WensharkCP;

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
            UserCP usercp = new UserCP();

            user = usercp.getUser(id);

            if (user == null) return this.Request.CreateErrorResponse(HttpStatusCode.NotFound, new Exception());

            return this.Request.CreateResponse(HttpStatusCode.OK, user);
        }

        [Authorize]
        public HttpResponseMessage postName(int id, string name)
        {
            //Si no es el usuario actual PUM!
            if (int.Parse(this.User.Identity.Name) != id) return this.Request.CreateErrorResponse(HttpStatusCode.Forbidden, new Exception());

            UserCP usercp = new UserCP();

            try
            {
                usercp.changeName(id, name);
                return this.Request.CreateResponse(HttpStatusCode.OK);
            }
            catch
            {
                //Si por algun casual falla, PUM!
                return this.Request.CreateErrorResponse(HttpStatusCode.NotFound, new Exception());
            }
        }

        [Authorize]
        public HttpResponseMessage postimage(int id, string image)
        {
            //Si no es el usuario actual PUM!
            if (int.Parse(this.User.Identity.Name) != id) return this.Request.CreateErrorResponse(HttpStatusCode.Forbidden, new Exception());

            UserCP usercp = new UserCP();

            try
            {
                usercp.changeImage(id, image);
                return this.Request.CreateResponse(HttpStatusCode.OK);
            }
            catch
            {
                //Si por algun casual falla, PUM!
                return this.Request.CreateErrorResponse(HttpStatusCode.NotFound, new Exception());
            }
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
            if (appuserCEN.IsValid(user, pass))
            {
                AppUserEN userEN = appuserCEN.GetByUsername(user)[0];
                FormsAuthentication.SetAuthCookie(userEN.Id.ToString(), false);

                var res = this.Request.CreateResponse(HttpStatusCode.OK, new { id = userEN.Id, name = userEN.Name });

                return res;
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public HttpResponseMessage PostSignUpAppUser(JObject data)
        {
            try
            {

                AppUserCEN usrCEN = new AppUserCEN();
                String name = data["name"].ToString();
                String pass = data["passw"].ToString();
                String username = data["username"].ToString();
                String email = data["email"].ToString();


                if (!usrCEN.Exist(username))
                {
                    int id = usrCEN.New_(pass, name, username, email, DateTime.Now, "/Assets/img/placeholder_user.png");
                    AppUserEN usr = new AppUserEN();
                    return this.Request.CreateResponse(HttpStatusCode.OK, id);
                }
                else
                {
                    return this.Request.CreateResponse(HttpStatusCode.Conflict, "Username ya existe.");
                }
            }
            catch (NullReferenceException)
            {
                return this.Request.CreateResponse(HttpStatusCode.BadRequest, "Parametros incorrectos");
            }
            catch (Exception)
            {
                return this.Request.CreateResponse(HttpStatusCode.InternalServerError, "Error Desconocido");
            }

        }

        public async Task<HttpResponseMessage> getOAuthValidate(string token)
        {
            String uri = "https://www.googleapis.com/oauth2/v1/tokeninfo?access_token=" + token;
            HttpClient httpclient = new HttpClient();
            HttpResponseMessage response = await httpclient.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                //Sacamos info usuario
                String uriuser = "https://www.googleapis.com/oauth2/v1/userinfo?access_token=" + token;
                response = await httpclient.GetAsync(uriuser);
                if (response.IsSuccessStatusCode)
                {
                    JObject data = await response.Content.ReadAsAsync<JObject>();
                    String idOAuth = data["id"].ToString();
                    OAuthUserEN user = new OAuthUserEN();
                    OAuthUserCEN userCEN = new OAuthUserCEN();

                    if (userCEN.Exist(idOAuth))
                    {
                        user = userCEN.GetByidOAuth(idOAuth)[0];
                    }
                    else
                    {
                        user.Name = data["name"].ToString();
                        user.Id = userCEN.New_(idOAuth, token, user.Name, data["email"].ToString(), DateTime.Now, -1, data["picture"].ToString());
                    }

                    FormsAuthentication.SetAuthCookie(user.Id.ToString(), false);
                    return this.Request.CreateResponse(HttpStatusCode.OK, new { id = user.Id, name = user.Name });

                }
                else
                {
                    return this.Request.CreateResponse(HttpStatusCode.BadRequest);
                }
            }
            else
            {
                return this.Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

    }
}
