using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Trabalho_Final_MOD_17E.Data;
using Trabalho_Final_MOD_17E.Models;

namespace Trabalho_Final_MOD_17E.Controllers
{
    public class LoginController : Controller
    {
        private Trabalho_Final_MOD_17EContext db = new Trabalho_Final_MOD_17EContext();

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(User user)
        {
            if (user.email != null && user.password != null)
            {
                //encriptar password
                HMACSHA512 hMACSHA512 = new HMACSHA512(new byte[] { 164 });
                var password = hMACSHA512.ComputeHash(Encoding.UTF8.GetBytes(user.password));
                user.password = Convert.ToBase64String(password);

                foreach(var utilizador in db.Users.ToList())
                {
                    if (utilizador.email == user.email && utilizador.password == user.password)
                    {
                        //iniciar sessão
                        FormsAuthentication.SetAuthCookie(user.email, false);

                        //redirecionar o user para ação
                        if (Request.QueryString["ReturnUrl"] == null)
                            return RedirectToAction("Index", "Home");
                        else
                            return Redirect(Request.QueryString["ReturnUrl"].ToString());
                    }
                }
            }
            ModelState.AddModelError("", "Login falhou. Tente novamente.");
            return View(user);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}