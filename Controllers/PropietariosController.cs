using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Inmobiliaria.Models;

namespace inmobiliaria.Controllers
{
    public class PropietariosController : Controller
    {   
        private readonly RepositorioPropietario Repo;

        public PropietariosController(){
            Repo = new RepositorioPropietario();

        }
        // GET: Propietarios
        public ActionResult IndexP()
        {   
            var lista = Repo.GetPropietarios();
            return View(lista);
            
        }

        // GET: Propietarios/Details/5
        public ActionResult DetallePropietario(int id)
        {
            var inquilino = Repo.ObtenerPropietario(id);
            return View(inquilino);
        }

        // GET: Propietarios/Create
        public ActionResult CrearPropietario()
        {
            return View();
        }
      

        // POST: Propietarios/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CrearPropietario(Propietarios propietario)
        {
           try
            {
                
            int res = Repo.Alta(propietario);
            if(res> 0 )
            {
                return RedirectToAction(nameof(IndexP));
            }
            else{
                return View(propietario);
            }
               

               
            }
            catch
            {
                return View();
            }
        }

        // GET: Propietarios/Edit/5
        public ActionResult EditarPropietario(int id)
        {
            var inquilino = Repo.ObtenerPropietario(id);
            return View(inquilino);
        }

        // POST: Propietarios/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditarPropietario(int id, Propietarios propietario)
        {
            try
            {
              Repo.Modificar(propietario);

                return RedirectToAction(nameof(IndexP));
            }
            catch
            {
                return View();
            }
        }

        // GET: Propietarios/Delete/5
        public ActionResult BorrarPropietario(int id)
        {
          var propietarios = Repo.ObtenerPropietario(id);
            return View(propietarios);
        }

        // POST: Propietarios/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult BorrarPropietario(int id, IFormCollection collection)
        {
            try
            {
                Repo.Borrar(id);

                return RedirectToAction(nameof(IndexP));
            }
            catch
            {
                return View();
            }
        }
    }
}

