using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjetoWeb.Models;

namespace ProjetoWeb.Controllers
{
    public class ContatoController : Controller
    {
        // GET: Contato
        public ActionResult Index()
        {
            using (ContatoModel model = new ContatoModel())
            {
                List<Contato> lista = model.Read();
                return View(lista);
            }
        }

        //temos uma sobrecarga de metodos

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(FormCollection form)
        {
            Contato contato = new Contato();
            contato.Nome = form["Nome"];
            contato.Email = form["Email"];

            using (ContatoModel model = new ContatoModel())
            {
                model.Create(contato);
                return RedirectToAction("Index");
            }
        }

        // GET: /Movies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contato contato = new Contato.Find(id);
            if (contato == null)
            {
                return HttpNotFound();
            }
            return View(contato);
        }

        // POST: /Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            int contato = id;
            using (ContatoModel model = new ContatoModel())
            {
                model.Delete(contato);
                return RedirectToAction("Index");

            }
        }

        
        public ActionResult Edit(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contato contato = new Contato.Find(id);
            if (contato == null)
            {
                return HttpNotFound();
            }
            return View(contato);
        }

        [HttpPost]
        public ActionResult Edit([Bind(Include= "IdContato,Nome,Email")]Contato contato)
        {

            using (ContatoModel model = new ContatoModel())
            {
                model.Edit(contato);
                return RedirectToAction("Index");

            }
        }
    }
}

    
