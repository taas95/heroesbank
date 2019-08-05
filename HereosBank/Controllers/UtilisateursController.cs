using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HereosBank.Models;

namespace HereosBank.Controllers
{
    public class UtilisateursController : Controller
    {
        private HereosModel db = new HereosModel();

        // GET: Utilisateurs
        public ActionResult Index()
        {
            var users = db.Users.Include(u => u.Privilege);
            return View(users.ToList());
        }

        // GET: Utilisateurs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Utilisateur utilisateur = db.Users.Find(id);
            if (utilisateur == null)
            {
                return HttpNotFound();
            }
            return View(utilisateur);
        }

        // GET: Utilisateurs/Create
        public ActionResult Create()
        {
            ViewBag.PrivilegeId = new SelectList(db.Privileges, "Id", "Profile");
            return View();
        }

        // POST: Utilisateurs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nom,Prenom,NumeroCarte,Sexe,DateNaissance,Email,Mdp,PrivilegeId")] Utilisateur utilisateur)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(utilisateur);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PrivilegeId = new SelectList(db.Privileges, "Id", "Profile", utilisateur.PrivilegeId);
            return View(utilisateur);
        }

        // GET: Utilisateurs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Utilisateur utilisateur = db.Users.Find(id);
            if (utilisateur == null)
            {
                return HttpNotFound();
            }
            ViewBag.PrivilegeId = new SelectList(db.Privileges, "Id", "Profile", utilisateur.PrivilegeId);
            return View(utilisateur);
        }

        // POST: Utilisateurs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nom,Prenom,NumeroCarte,Sexe,DateNaissance,Email,Mdp,PrivilegeId")] Utilisateur utilisateur)
        {
            if (ModelState.IsValid)
            {
                db.Entry(utilisateur).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PrivilegeId = new SelectList(db.Privileges, "Id", "Profile", utilisateur.PrivilegeId);
            return View(utilisateur);
        }

        // GET: Utilisateurs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Utilisateur utilisateur = db.Users.Find(id);
            if (utilisateur == null)
            {
                return HttpNotFound();
            }
            return View(utilisateur);
        }

        // POST: Utilisateurs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Utilisateur utilisateur = db.Users.Find(id);
            db.Users.Remove(utilisateur);
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
