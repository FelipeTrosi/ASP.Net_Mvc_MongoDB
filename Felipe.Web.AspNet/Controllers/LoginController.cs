using Felipe.Web.AspNet.Classes;
using Felipe.Web.AspNet.Models;
using MongoDB.Driver;
using MVC.Web.AspNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Felipe.Web.AspNet.Controllers
{
    public class LoginController : Controller
    {
        private MongoDBContext _context;
        private IMongoCollection<Estudante> _estudanteCollection;

        public LoginController()
        {
            _context = new MongoDBContext();
            _estudanteCollection = _context.database.GetCollection<Estudante>("Estudantes");
        }

        // GET: Login
        public ActionResult Login()
        {
            ValidaSession.Autenticado = false;
            ValidaSession.CodigoUsuario = null;
            ValidaSession.NomeUsuario = null;
            return View();
        }

        [HttpPost]
        public ActionResult Login(Login login)
        {
            var estudante = _estudanteCollection.AsQueryable<Estudante>().Where(e => e.User == login.User && e.Password == login.Password).FirstOrDefault();

            if (ModelState.IsValid)
            {            
                if (estudante != null)
                {

                    ValidaSession.Autenticado = true;
                    ValidaSession.CodigoUsuario = estudante.Id;
                    ValidaSession.NomeUsuario = estudante.Nome;
                    return RedirectToAction("Index", "Usuario", estudante);

                } 
            }
            return RedirectToAction("Login");
        }
    }
}