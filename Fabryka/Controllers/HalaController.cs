﻿using System;
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
    public class HalaController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Hala
        public ActionResult Index()
        {
            return View(db.Halas.ToList());
        }

        // GET: Hala/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hala hala = db.Halas.Find(id);
            if (hala == null)
            {
                return HttpNotFound();
            }
            return View(hala);
        }

        // GET: Hala/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Hala/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nazwa,Adres")] Hala hala)
        {
            if (ModelState.IsValid)
            {
                db.Halas.Add(hala);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(hala);
        }

        // GET: Hala/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hala hala = db.Halas.Find(id);
            if (hala == null)
            {
                return HttpNotFound();
            }
            return View(hala);
        }

        // POST: Hala/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nazwa,Adres")] Hala hala)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hala).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(hala);
        }

        // GET: Hala/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hala hala = db.Halas.Find(id);
            if (hala == null)
            {
                return HttpNotFound();
            }
            return View(hala);
        }

        // POST: Hala/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Hala hala = db.Halas.Find(id);
            db.Halas.Remove(hala);
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
