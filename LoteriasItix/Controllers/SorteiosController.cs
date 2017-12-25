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
    public class SorteiosController : Controller
    {
        private Context db = new Context();

        // GET: Sorteios
        public ActionResult Index()
        {
            return View(db.Sorteios.ToList());
        }

        // GET: Sorteios/Details/5
        public ActionResult Details(int? id)
        {
            var sn1 = 0;
            var sn2 = 0;
            var sn3 = 0;
            var sn4 = 0;
            var sn5 = 0;
            var sn6 = 0;
            var idd = id;
            var sena = 0;
            var quina = 0;
            var quadra = 0;
            var acertos = 0;

            ICollection<Aposta> apostas = db.Apostas.ToList();
            List<Sorteio> sorteios = db.Sorteios.ToList();
            Sorteio sorteio1 = sorteios.Where(s => s.SorteioId == id).Single();
            sn1 = sorteio1.Numeros.N1;
            sn2 = sorteio1.Numeros.N2;
            sn3 = sorteio1.Numeros.N3;
            sn4 = sorteio1.Numeros.N4;
            sn5 = sorteio1.Numeros.N5;
            sn6 = sorteio1.Numeros.N6;

            foreach (Aposta a in apostas)
            {
               if (a.NumeroSorteio == id)
                {
                    if(a.Numeros.N1==sn1 || a.Numeros.N1 == sn2 || a.Numeros.N1 == sn3 || a.Numeros.N1 == sn4 || a.Numeros.N1 == sn5 || a.Numeros.N1 == sn6)
                    {
                        acertos = acertos + 1;
                    }
                    if (a.Numeros.N2 == sn1 || a.Numeros.N2 == sn2 || a.Numeros.N2 == sn3 || a.Numeros.N2 == sn4 || a.Numeros.N2 == sn5 || a.Numeros.N2 == sn6)
                    {
                        acertos = acertos + 1;
                    }
                    if (a.Numeros.N3 == sn1 || a.Numeros.N3 == sn2 || a.Numeros.N3 == sn3 || a.Numeros.N3 == sn4 || a.Numeros.N3 == sn5 || a.Numeros.N3 == sn6)
                    {
                        acertos = acertos + 1;
                    }
                    if (a.Numeros.N4 == sn1 || a.Numeros.N4 == sn2 || a.Numeros.N4 == sn3 || a.Numeros.N4 == sn4 || a.Numeros.N4 == sn5 || a.Numeros.N4 == sn6)
                    {
                        acertos = acertos + 1;
                    }
                    if (a.Numeros.N5 == sn1 || a.Numeros.N5 == sn2 || a.Numeros.N5 == sn3 || a.Numeros.N5 == sn4 || a.Numeros.N5 == sn5 || a.Numeros.N5 == sn6)
                    {
                        acertos = acertos + 1;
                    }
                    if (a.Numeros.N6== sn1 || a.Numeros.N6 == sn2 || a.Numeros.N6 == sn3 || a.Numeros.N6 == sn4 || a.Numeros.N6 == sn5 || a.Numeros.N6 == sn6)
                    {
                        acertos = acertos + 1;
                    }

                    if (acertos == 6) { sena = sena + 1;}
                    else if (acertos == 5) { quina = quina + 1;}
                    else if (acertos == 4) { quadra = quadra + 1;}
                    acertos = 0;
                }
            }

            ViewBag.Sena = sena.ToString();
            ViewBag.Quina = quina.ToString();
            ViewBag.Quadra = quadra.ToString();

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sorteio sorteio = db.Sorteios.Find(id);
            if (sorteio == null)
            {
                return HttpNotFound();
            }
            return View(sorteio);
        }

        // GET: Sorteios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Sorteios/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SorteioId,Numeros,Data")] Sorteio sorteio)
        {
            if (ModelState.IsValid)
            {
                sorteio.Data = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
                db.Sorteios.Add(sorteio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sorteio);
        }

        // GET: Sorteios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sorteio sorteio = db.Sorteios.Find(id);
            if (sorteio == null)
            {
                return HttpNotFound();
            }
            return View(sorteio);
        }

        // POST: Sorteios/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SorteioId,Numeros,Data")] Sorteio sorteio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sorteio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sorteio);
        }

        // GET: Sorteios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sorteio sorteio = db.Sorteios.Find(id);
            if (sorteio == null)
            {
                return HttpNotFound();
            }
            return View(sorteio);
        }

        // POST: Sorteios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sorteio sorteio = db.Sorteios.Find(id);
            db.Sorteios.Remove(sorteio);
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
