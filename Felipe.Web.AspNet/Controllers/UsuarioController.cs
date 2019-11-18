using Felipe.Web.AspNet.Classes;
using MongoDB.Bson;
using MongoDB.Driver;
using MVC.Web.AspNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Felipe.Web.AspNet.Controllers
{
    public class UsuarioController : Controller
    {
        private MongoDBContext _context;
        private IMongoCollection<Estudante> _estudanteCollection;

        public UsuarioController()
        {
            _context = new MongoDBContext();
            _estudanteCollection = _context.database.GetCollection<Estudante>("Estudantes");
        }

        // GET: Usuario
        [HttpGet]
        public ActionResult Index()
        {
            if (!ValidaSession.Autenticado)
            {
                return RedirectToAction("Login", "Login", null);
            }
            else
            {
                List<Estudante> estudantes = _estudanteCollection.AsQueryable<Estudante>().ToList();
                return View(estudantes);
            }
            
        }

        //CASDASTRAR
        [HttpGet]
        public ActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(Estudante estudante)
        {

            try
            {
                _estudanteCollection.InsertOne(estudante);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {

                return View();
            }
            
        }
        
        //EDITAR
        [HttpGet]
        public ActionResult Editar(string id)
        {
            var estudante = _estudanteCollection.AsQueryable<Estudante>().SingleOrDefault(x => x.Id == id);
            return View(estudante);
        }

        [HttpPost]
        public ActionResult Editar(string id, Estudante estudante)
        {

            try
            {
                var filter = Builders<Estudante>.Filter.Eq("_id", ObjectId.Parse(id));

                var novoEstudante = Builders<Estudante>.Update.Set("nome", estudante.Nome)
                .Set("curso", estudante.Curso)
                .Set("user", estudante.User)
                .Set("password", estudante.Password)
                .Set("rm", estudante.Rm)
                .Set("dataMatricula", estudante.DataMatricula)
                .Set("valorMensalidade", estudante.ValorMensalidade);

                var result = _estudanteCollection.UpdateOne(filter, novoEstudante);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);                
                return View();
            }
            
        }

        //EXCLUIR
        [HttpGet]
        public ActionResult Excluir(string id)
        {
            var estudante = _estudanteCollection.AsQueryable<Estudante>().SingleOrDefault(x => x.Id == id);
            return View(estudante);
        }
         
        [HttpPost]
        public ActionResult Excluir(string id, Estudante estudante)
        {
            try
            {
                _estudanteCollection.DeleteOne(Builders<Estudante>.Filter.Eq("_id", ObjectId.Parse(id)));
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return View();
            }
        }



    }
}