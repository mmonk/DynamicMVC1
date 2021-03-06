﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DynamicMVC1.Models;

namespace DynamicMVC1.Controllers
{
    public class userDatasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: userDatas
        public ActionResult Index()
        {
            return View(db.userDatas.ToList());
        }

        // GET: userDatas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            userData userData = db.userDatas.Find(id);
            if (userData == null)
            {
                return HttpNotFound();
            }
            return View(userData);
        }

        // GET: userDatas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: userDatas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,FirstName,LastName,Address,City,State,ZipCode,Phone,Email,Date_of_Birth,Message")] userData userData)
        {
            if (ModelState.IsValid)
            {
                db.userDatas.Add(userData);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(userData);
        }

        // GET: userDatas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            userData userData = db.userDatas.Find(id);
            if (userData == null)
            {
                return HttpNotFound();
            }
            return View(userData);
        }

        // POST: userDatas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,FirstName,LastName,Address,City,State,ZipCode,Phone,Email,Date_of_Birth,Message")] userData userData)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userData).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(userData);
        }

        // GET: userDatas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            userData userData = db.userDatas.Find(id);
            if (userData == null)
            {
                return HttpNotFound();
            }
            return View(userData);
        }

        // POST: userDatas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            userData userData = db.userDatas.Find(id);
            db.userDatas.Remove(userData);
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
