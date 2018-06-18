using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Fabryka.Models;

namespace Fabryka.Controllers
{
    public class MaszynaController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Maszyna
        public ActionResult Index(string wyszukaj_maszyne)
        {
            if (string.IsNullOrEmpty(wyszukaj_maszyne))
            {
                var maszynas = db.Maszynas.Include(m => m.Hala);
                return View(maszynas.ToList());
            } 
            else
            {
                var maszynas = db.Maszynas.Include(m => m.Hala).Where(m => m.Nazwa.Contains(wyszukaj_maszyne)).OrderBy(m => m.Nazwa);
                return View(maszynas.ToList());
            }
        }

        // GET: Maszyna/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Maszyna maszyna = db.Maszynas.Find(id);
            if (maszyna == null)
            {
                return HttpNotFound();
            }
            return View(maszyna);
        }

        // GET: Maszyna/Create
        public ActionResult Create()
        {
            ViewBag.HalaId = new SelectList(db.Halas, "Id", "Nazwa");
            ViewBag.Operator = new SelectList(db.Operators, "Id", "Imie");
            return View();
        }

        // POST: Maszyna/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Numer_ewidencyjny,Nazwa,Data_uru,Operatorzy,HalaId")] Maszyna maszyna)
        {
            if (ModelState.IsValid)
            {
                var operatorId = int.Parse(Request.Form["Operator"]);
                var Imie = from op in db.Operators
                           where op.Id == operatorId
                           select op.Imie;
                maszyna.Operatorzy = Imie.Single();
                db.Maszynas.Add(maszyna);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.HalaId = new SelectList(db.Halas, "Id", "Nazwa", maszyna.HalaId);
            return View(maszyna);
        }

        // GET: Maszyna/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Maszyna maszyna = db.Maszynas.Find(id);
            if (maszyna == null)
            {
                return HttpNotFound();
            }
            ViewBag.HalaId = new SelectList(db.Halas, "Id", "Nazwa", maszyna.HalaId);
            return View(maszyna);
        }

        // POST: Maszyna/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Numer_ewidencyjny,Nazwa,Data_uru,Operatorzy,HalaId")] Maszyna maszyna)
        {
            if (ModelState.IsValid)
            {
                db.Entry(maszyna).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.HalaId = new SelectList(db.Halas, "Id", "Nazwa", maszyna.HalaId);
            return View(maszyna);
        }

        // GET: Maszyna/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Maszyna maszyna = db.Maszynas.Find(id);
            if (maszyna == null)
            {
                return HttpNotFound();
            }
            return View(maszyna);
        }

        // POST: Maszyna/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Maszyna maszyna = db.Maszynas.Find(id);
            db.Maszynas.Remove(maszyna);
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
