using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Serilog;

namespace mmm.Controllers
{
    public class HomeController : Controller
    {
        mvccruddbContext _context = new mvccruddbContext();
        public ActionResult Index()
        {
            try
            {
                Log.Information("affichage");
                var listofData = _context.clients.ToList();
                return View(listofData);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "une erreur est apparu");
                return View("Error"); 
            }
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(client model)
        {
            try
            {
                Log.Information("creation");
                _context.clients.Add(model);
                _context.SaveChanges();
                ViewBag.Message = "Donnee insere";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Log.Error(ex, "une erreur est apparu durant la creation.");
                return View("Error");
            }
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            try
            {
                var data = _context.clients.Where(x => x.clientid == id).FirstOrDefault();
                return View(data);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "une erreur est apparu");
                return View("Error");
            }
        }

        [HttpPost]
        public ActionResult Edit(client model)
        {
            try
            {
                var data = _context.clients.Where(x => x.clientid == model.clientid).FirstOrDefault();
                if (data != null)
                {
                    Log.Information("modification");
                    data.clientnom = model.clientnom;
                    data.clientprix = model.clientprix;
                    data.clientnbrtitre = model.clientnbrtitre;
                    _context.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Log.Error(ex, "une erreur est apparu durant la modification");
                return View("Error");
            }
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            try
            {
                client c = _context.clients.Find(id);
                if (c == null)
                {
                    return HttpNotFound();
                }
                Log.Information("detail");
                return View(c);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "une erreur est apparu durant l'affichage des details");
                return View("Error");
            }
        }

        public ActionResult Delete(int id)
        {
            try
            {
                var data = _context.clients.Where(x => x.clientid == id).FirstOrDefault();
                if (data != null)
                {
                    Log.Information("suppresion");
                    _context.clients.Remove(data);
                    _context.SaveChanges();
                    ViewBag.Message = "donnee supprime";
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Log.Error(ex, "une erreur est apparu durant la suppresion");
                return View("Error");
            }
        }
        public ActionResult RedirectTitreIndex()
        {
            
            return RedirectToAction("Index", "Titre");
        }
    }
}
