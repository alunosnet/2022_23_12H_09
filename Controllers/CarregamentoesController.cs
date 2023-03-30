using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Trabalho_Final_MOD_17E.Data;
using Trabalho_Final_MOD_17E.Models;

namespace Trabalho_Final_MOD_17E.Controllers
{
    [Authorize]
    public class CarregamentoesController : Controller
    {
        private Trabalho_Final_MOD_17EContext db = new Trabalho_Final_MOD_17EContext();

        // GET: Carregamentoes
        public ActionResult Index()
        {
            if (User.IsInRole("Utilizador"))
            {
                var carregamentos = db.Carregamentos.Include(c => c.carregador).Include(c => c.user).Where(c => c.user.email == User.Identity.Name);
                return View(carregamentos.ToList());
            }
            else
            {
                var carregamentos = db.Carregamentos.Include(c => c.carregador).Include(c => c.user);
                return View(carregamentos.ToList());
            }
        }

        // GET: Carregamentoes/Details/5
        [Authorize(Roles = "Administrador")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var carregamento = db.Carregamentos.Find(id);
            if (carregamento == null)
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

            }
            var user = db.Users.Find(carregamento.UtilizadorID);
            var carregador = db.Carregadors.Find(carregamento.CarregadorID);
            carregamento.user = user;
            carregamento.carregador = carregador;
            return View(carregamento);
        }

        [Authorize(Roles = "Administrador")]
        // GET: Carregamentoes/Create
        public ActionResult Create()
        {
            ViewBag.CarregadorID = new SelectList(db.Carregadors, "CarregadorID", "CarregadorID");
            ViewBag.UtilizadorID = new SelectList(db.Users, "UserID", "nome");
            return View();
        }

        // POST: Carregamentoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrador")]
        public ActionResult Create([Bind(Include = "CarregamentoID,data_carregamento,UtilizadorID,CarregadorID,kWh,preco_total")] Carregamento carregamento)
        {
            if (ModelState.IsValid)
            {
                db.Carregamentos.Add(carregamento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CarregadorID = new SelectList(db.Carregadors.Where(c => c.Estado == false), "CarregadorID", "Localidade", carregamento.CarregadorID);
            ViewBag.UtilizadorID = new SelectList(db.Users, "UserID", "nome", carregamento.UtilizadorID);
            return View(carregamento);
        }

        // GET: Carregamentoes/Edit/5
        [Authorize(Roles = "Administrador")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Carregamento carregamento = db.Carregamentos.Find(id);
            if (carregamento == null)
            {
                return HttpNotFound();
            }
            ViewBag.CarregadorID = new SelectList(db.Carregadors.Where(c => c.Estado == false || c.CarregadorID == carregamento.CarregadorID), "CarregadorID", "Localidade", carregamento.CarregadorID);
            ViewBag.UtilizadorID = new SelectList(db.Users, "UserID", "nome", carregamento.UtilizadorID);
            return View(carregamento);
        }

        // POST: Carregamentoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrador")]
        public ActionResult Edit([Bind(Include = "CarregamentoID,data_carregamento,UtilizadorID,CarregadorID,kWh,preco_total")] Carregamento carregamento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(carregamento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CarregadorID = new SelectList(db.Carregadors, "CarregadorID", "Localidade", carregamento.CarregadorID);
            ViewBag.UtilizadorID = new SelectList(db.Users, "UserID", "nome", carregamento.UtilizadorID);
            return View(carregamento);
        }

        //// GET: Carregamentoes/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Carregamento carregamento = db.Carregamentos.Find(id);
        //    if (carregamento == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(carregamento);
        //}

        //// POST: Carregamentoes/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Carregamento carregamento = db.Carregamentos.Find(id);
        //    db.Carregamentos.Remove(carregamento);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

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
