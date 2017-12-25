using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LoteriasItix.Models;

namespace LoteriasItix.Controllers
{
    public class ApostasController : Controller
    {
        private Context db = new Context();

        // GET: Apostas
        public ActionResult Index()
        {
            return View(db.Apostas.ToList());
        }

        // GET: Apostas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aposta aposta = db.Apostas.Find(id);
            if (aposta == null)
            {
                return HttpNotFound();
            }
            return View(aposta);
        }

        // GET: Apostas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Apostas/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "JogoId,NumeroSorteio,Numeros,Data")] Aposta aposta)
        {
            if (ModelState.IsValid)
            {
                aposta.NumeroSorteio = ((db.Sorteios.ToList()).Count) + 1;
                aposta.Data = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
                db.Apostas.Add(aposta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(aposta);
        }

        // GET: Apostas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aposta aposta = db.Apostas.Find(id);
            if (aposta == null)
            {
                return HttpNotFound();
            }
            return View(aposta);
        }

        // POST: Apostas/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "JogoId,NumeroSorteio,Numeros,Data")] Aposta aposta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aposta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(aposta);
        }

        // GET: Apostas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aposta aposta = db.Apostas.Find(id);
            if (aposta == null)
            {
                return HttpNotFound();
            }
            return View(aposta);
        }

        // POST: Apostas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Aposta aposta = db.Apostas.Find(id);
            db.Apostas.Remove(aposta);
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
