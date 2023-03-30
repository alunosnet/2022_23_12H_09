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
    public class CarregadoresController : Controller
    {
        private Trabalho_Final_MOD_17EContext db = new Trabalho_Final_MOD_17EContext();

        // GET: Carregadores
        public ActionResult Index()
        {
            return View(db.Carregadors.ToList());
        }

        // GET: Carregadores/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Carregador carregador = db.Carregadors.Find(id);
            if (carregador == null)
            {
                return HttpNotFound();
            }
            return View(carregador);
        }

        [Authorize(Roles = "Administrador")]
        // GET: Carregadores/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Carregadores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrador")]
        public ActionResult Create([Bind(Include = "CarregadorID,Localidade,Empresa,Estado,Preco_por_kWh,Latitude,Longitude")] Carregador carregador)
        {
            if (ModelState.IsValid)
            {
                db.Carregadors.Add(carregador);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(carregador);
        }

        // GET: Carregadores/Edit/5
        [Authorize(Roles = "Administrador")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Carregador carregador = db.Carregadors.Find(id);
            if (carregador == null)
            {
                return HttpNotFound();
            }
            return View(carregador);
        }

        // POST: Carregadores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrador")]
        public ActionResult Edit([Bind(Include = "CarregadorID,Localidade,Empresa,Estado,Preco_por_kWh,Latitude,Longitude")] Carregador carregador)
        {
            if (ModelState.IsValid)
            {
                db.Entry(carregador).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(carregador);
        }

        // GET: Carregadores/Delete/5
        [Authorize(Roles = "Administrador")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Carregador carregador = db.Carregadors.Find(id);
            if (carregador == null)
            {
                return HttpNotFound();
            }
            return View(carregador);
        }

        // POST: Carregadores/Delete/5
        [Authorize(Roles = "Administrador")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Carregador carregador = db.Carregadors.Find(id);
            db.Carregadors.Remove(carregador);
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
