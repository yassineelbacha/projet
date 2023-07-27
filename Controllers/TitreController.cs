using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using mmm;
using Serilog;

namespace mmm.Controllers
{
    public class TitreController : Controller
    {
        private mvccruddbContext _context = new mvccruddbContext();

        // GET: Titres
        public ActionResult Index()
        {
            try
            {
                Log.Information("affichage");
                var titre = _context.Titres.Include(t => t.client);
                return View(titre.ToList());
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Une erreur est apparu");
                ViewBag.ErrorMessage = "Une erreur s'est produite lors du chargement des titres.";
                return View("Error");
            }
        }

        // GET: Titres/Details/5
        public ActionResult Details(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                Titre titre = _context.Titres.Find(id);
                if (titre == null)
                {
                    return HttpNotFound();
                }
                Log.Information("details");
                return View(titre);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Une erreur est apparru");
                ViewBag.ErrorMessage = "Une erreur s'est produite lors du chargement des détails du titre.";
                return View("Error");
            }
        }

        // GET: Titres/Create
        public ActionResult Create()
        {
            try
            {
                Log.Information("ajout");
                ViewBag.idclient = new SelectList(_context.clients, "clientid", "clientnom");

                var titre = new Titre
                {
                    ListeVilles = new List<string>
            {
                "Casablanca",
                "Rabat",
                "Marrakech",
                "Fès",
                "Tanger",
                "Tetouan",
                "Agadir"
            }
                };

                return View(titre);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Une erreur est apparru");
                return View("Error");
            }
        }

        // POST: Titres/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Idtitre,datetitre,prixtitre,villetitre,idclient")] Titre titre)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Log.Information("ajout");
                    var client = _context.clients.Find(titre.idclient);
                    client.Titre = titre;
                    _context.Titres.Add(titre);
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }

                ViewBag.idclient = new SelectList(_context.clients, "clientid", "clientnom", titre.idclient);

                titre.ListeVilles = new List<string>
        {
            "Casablanca",
            "Rabat",
            "Marrakech",
            "Fès",
            "Tanger",
            "Tetouan",
            "Agadir"
        };

                return View(titre);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Une erreur est apparru");
                return View("Error");
            }
        }


        // GET: Titres/Edit/5
        public ActionResult Edit(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                Titre titre = _context.Titres.Find(id);
                if (titre == null)
                {
                    return HttpNotFound();
                }
                Log.Information("modification");
                ViewBag.idclient = new SelectList(_context.clients, "clientid", "clientnom", titre.idclient);
                ViewBag.ListeVilles = new List<string>
                {
                    "Casablanca",
                    "Rabat",
                    "Marrakech",
                    "Fès",
                    "Tanger",
                    "Tetouan",
                    "Agadir",
                };

                return View(titre);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Une erreur est apparru");
                return View("Error");
            }
        }

        // POST: Titres/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Idtitre,datetitre,prixtitre,villetitre,idclient")] Titre titre)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Entry(titre).State = EntityState.Modified;
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
                Log.Information("modification");
                ViewBag.idclient = new SelectList(_context.clients, "clientid", "clientnom", titre.idclient);
                ViewBag.ListeVilles = new List<string>
                {
                    "Casablanca",
                    "Rabat",
                    "Marrakech",
                    "Fès",
                    "Tanger",
                    "Tetouan",
                    "Agadir",
                };

                return View(titre);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Une erreur est apparru");
                return View("Error");
            }
        }

        // GET: Titres/Delete/5
        public ActionResult Delete(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                Titre titre = _context.Titres.Find(id);
                if (titre == null)
                {
                    return HttpNotFound();
                }

                return View(titre);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Une erreur est apparru");
                return View("Error");
            }
        }

        // POST: Titres/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                Log.Information("suppresion");
                Titre titre = _context.Titres.Find(id);
                _context.Titres.Remove(titre);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Une erreur est apparru");
                return View("Error");
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }
        public ActionResult RedirectHomeIndex()
        {
            return RedirectToAction("Index", "Home");
        }

    }
}
