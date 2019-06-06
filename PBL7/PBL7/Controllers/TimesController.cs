using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PBL7.Models;
using Rotativa;

namespace PBL7.Controllers
{
    public class TimesController : Controller
    {
        private PBL7Context db = new PBL7Context();

        // GET: Times
        public ActionResult Index()
        {
            var times = db.Times.Include(t => t.Patrocinador);
            return View(times.ToList());
        }

        // GET: Times/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Time time = db.Times.Find(id);
            if (time == null)
            {
                return HttpNotFound();
            }
            return View(time);
        }

        // GET: Times/Create
        public ActionResult Create()
        {
            ViewBag.JogadorId = new MultiSelectList(db.Jogadors, "JogadorId", "Nome");
            ViewBag.PatrocinadorId = new SelectList(db.Patrocinadors, "PatrocinadorId", "Nome");
            return View();
        }
        //Relatorio
        public ActionResult RelatorioTimes()
        {
            List<Time> times;
            times = db.Times.OrderByDescending(a => a.NumeroVitorias).ToList();
            var pdf = new ViewAsPdf
            {
                ViewName = "RelatorioTimes",
                IsGrayScale = true,
                PageSize = Rotativa.Options.Size.A4,
                Model = times.ToPagedList(1, times.Count())
            };
            return pdf;
        }
    
        // POST: Times/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TimeId,Nome,PatrocinadorId,NumeroVitorias")] Time time, List<int>JogadorId)
        {
            if (ModelState.IsValid)
            {
                foreach(int jogadorr in JogadorId)
                {
                    var adicionajogdor = db.Jogadors.Find(jogadorr);
                    time.Jogadores.Add(adicionajogdor);
                }
                db.Times.Add(time);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.JogadorId = new MultiSelectList(db.Jogadors, "PatrocinadorId", "Nome");
            ViewBag.PatrocinadorId = new SelectList(db.Patrocinadors, "PatrocinadorId", "Nome");
            return View(time);
        }

        // GET: Times/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Time time = db.Times.Find(id);
            if (time == null)
            {
                return HttpNotFound();
            }
            ViewBag.PatrocinadorId = new SelectList(db.Patrocinadors, "PatrocinadorId", "Nome", time.PatrocinadorId);
            return View(time);
        }

        // POST: Times/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TimeId,Nome,PatrocinadorId,NumeroVitorias")] Time time)
        {
            if (ModelState.IsValid)
            {
                db.Entry(time).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PatrocinadorId = new SelectList(db.Patrocinadors, "PatrocinadorId", "Nome", time.PatrocinadorId);
            return View(time);
        }

        // GET: Times/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Time time = db.Times.Find(id);
            if (time == null)
            {
                return HttpNotFound();
            }
            return View(time);
        }

        // POST: Times/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Time time = db.Times.Find(id);
            db.Times.Remove(time);
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
