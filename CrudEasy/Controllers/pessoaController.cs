using CrudEasy.infra;
using CrudEasy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CrudEasy.Controllers
{
    public class pessoaController : Controller
    {
        // GET: pessoa
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetPessoa()
        {
            Contexto contexto = new Contexto();
            List<Pessoa> ListPessoa = contexto.Pessoas.ToList();
            return Json(ListPessoa, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult SalvarPessoa(Pessoa p)
        {
            Contexto contexto = new Contexto();
            contexto.Pessoas.Add(p);
            contexto.SaveChanges();

            List<Pessoa> ListPessoa = contexto.Pessoas.ToList();
            return Json(ListPessoa, JsonRequestBehavior.AllowGet);

        }


        [HttpPost]
        public JsonResult EditarPessoa(int id)
        {
            Contexto contexto = new Contexto();
            Pessoa p = new Pessoa();
            p = contexto.Pessoas.Find(id);

            return Json(p, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult AtualizarPessoa(Pessoa p)
        {
            Contexto contexto = new Contexto();
            contexto.Entry(p).State = System.Data.Entity.EntityState.Modified;
            contexto.SaveChanges();

            List<Pessoa> ListPessoa = contexto.Pessoas.ToList();
            return Json(ListPessoa, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult DeletarPessoa(int id)
        {
            Contexto contexto = new Contexto();
            Pessoa p = new Pessoa();
            p = contexto.Pessoas.Find(id);
            contexto.Entry(p).State = System.Data.Entity.EntityState.Deleted;
            contexto.SaveChanges();

            List<Pessoa> ListPessoa = contexto.Pessoas.ToList();
            return Json(ListPessoa, JsonRequestBehavior.AllowGet);

        }

    }
}