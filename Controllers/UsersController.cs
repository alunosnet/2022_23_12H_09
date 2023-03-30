using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Trabalho_Final_MOD_17E.Data;
using Trabalho_Final_MOD_17E.Models;

namespace Trabalho_Final_MOD_17E.Controllers
{
    [Authorize]
    public class UsersController : Controller
    {
        private Trabalho_Final_MOD_17EContext db = new Trabalho_Final_MOD_17EContext();

        [Authorize(Roles = "Administrador")]
        // GET: Users
        public ActionResult Index()
        {
            return View(db.Users.ToList());
        }

        [Authorize(Roles = "Administrador")]
        // GET: Users/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //incluir carregamentos
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        [Authorize(Roles = "Administrador")]
        // GET: Users/Create
        public ActionResult Create()
        {
            var utilizador = new User();
            utilizador.perfis = new[]
            {
                new SelectListItem{Value = "0", Text="Administrador"},
                new SelectListItem{Value = "1", Text="Utilizador"}
            };
            return View(utilizador);
        }

        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrador")]
        public ActionResult Create([Bind(Include = "UserID,nome,email,Password,perfil")] User user)
        {
            user.perfis = new[]
            {
                new SelectListItem{Value = "0", Text="Administrador"},
                new SelectListItem{Value = "1", Text="Utilizador"}
            };
            if (ModelState.IsValid)
            {
                //testar se já existe um user com o mesmo email
                var t = db.Users.Where(u => u.email.Equals(user.email)).ToList();
                if (t!=null && t.Count>0)
                {
                    ModelState.AddModelError("nome", "Já existe um utilizador com esse email.");
                    return View(user);
                }
                //validar password
                if (user.password == null || user.password.Trim().Length<5)
                {
                    ModelState.AddModelError("Password", "Password não é váldia");
                    return View(user);
                }

                //encriptar password
                HMACSHA512 hMACSHA512 = new HMACSHA512(new byte[] {164});
                var password = hMACSHA512.ComputeHash(Encoding.UTF8.GetBytes(user.password));
                user.password = Convert.ToBase64String(password);

                db.Users.Add(user);
                db.SaveChanges();

                //fotogradia
                HttpPostedFileBase fotografia = Request.Files["fotografia"];
                if (fotografia != null && fotografia.ContentLength > 0)
                {
                    string imagem = Server.MapPath("~/Fotos/") + user.UserID + ".jpg";
                    fotografia.SaveAs(imagem);
                }

                return RedirectToAction("Index");
            }

            return View(user);
        }

        // GET: Users/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }

            //tester se é admin
            if (User.IsInRole("Utilizador"))
            {
                //Verificar se o id é igual ao id do user autenticado
                var t = db.Users.Where(u => u.email == User.Identity.Name && id == u.UserID).FirstOrDefault();
                if (t == null)
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

                user.perfis = new[]
                {
                    new SelectListItem{Value = "1", Text="Utilizador"}
                };


            }
            else
            {
                user.perfis = new[]
                {
                    new SelectListItem{Value = "0", Text="Administrador"},
                    new SelectListItem{Value = "1", Text="Utilizador"}
                };
            }

            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserID,nome,password,email,perfil")] User user)
        {
            if (ModelState.IsValid)
            {
                //var t = db.Users.Where(a => a.email.Equals(user.email)).ToList();
                //if (t != null && t.Count > 1)
                //{
                //    ModelState.AddModelError("nome", "Já existe um utilizador com esse email.");
                //    return View(user);
                //}
                var u = db.Users.Find(user.UserID);
                u.nome = user.nome;
                u.perfil = user.perfil;
                u.email = user.email;

                db.Entry(u).State = EntityState.Modified;
                db.SaveChanges();
                if (User.IsInRole("Utilizador"))
                {
                    return RedirectToAction("Index", "Home");
                }
                return RedirectToAction("Index");
            }
            //tester se é admin
            if (User.IsInRole("Utilizador"))
            {
                //Verificar se o id é igual ao id do user autenticado
                var t = db.Users.Where(u => u.email == User.Identity.Name && user.UserID == u.UserID).First();
                if (t == null)
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

                user.perfis = new[]
                {
                    new SelectListItem{Value = "1", Text="Utilizador"}
                };
            }
            else
            {
                user.perfis = new[]
                {
                    new SelectListItem{Value = "0", Text="Administrador"},
                    new SelectListItem{Value = "1", Text="Utilizador"}
                };
            }
            //AINDA QUER UMA PALAVRA PASSE
            ModelState.AddModelError("", "Ocurreu algum erro.");

            if (User.IsInRole("Amdinistrador"))
            {
                return View(user);
            }

            return RedirectToAction("Index", "Home");
        }

        // GET: Users/Delete/5
        [Authorize(Roles = "Administrador")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = db.Users.Find(id);
            db.Users.Remove(user);
            db.SaveChanges();
            return RedirectToAction("Index");
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
