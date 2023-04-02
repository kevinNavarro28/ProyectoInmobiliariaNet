using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Inmobiliaria.Models;

namespace inmobiliaria.Controllers
{
    public class InquilinosController : Controller
    {
        private readonly RepositorioInquilino Repo;

        public InquilinosController(){
            Repo = new RepositorioInquilino();
        }
        // GET: Inquilinos
        public ActionResult IndexI()
        {   
            
            var lista = Repo.GetInquilinos();
            return View(lista);
        }

        // GET: Inquilinos/Details/5
        public ActionResult DetalleInquilino(int id)
        {
            var inquilino = Repo.ObtenerInquilino(id);
            return View(inquilino);
        }

        // GET: Inquilinos/Create
        public ActionResult CrearInquilino()
        {
            return View();
        }

        // POST: Inquilinos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CrearInquilino(Inquilinos inquilino)
        {
            


            try
            {
                
            int res = Repo.Alta(inquilino);
            if(res> 0 )
            {
                return RedirectToAction(nameof(IndexI));
            }
            else{
                return View(inquilino);
            }
               

               
            }
            catch(Exception ex)
            {
                return View();
            }
        }

        // GET: Inquilinos/Edit/5
        public ActionResult EditarInquilino(int id)
        {
            var inquilino = Repo.ObtenerInquilino(id);
            return View(inquilino);
        }

        // POST: Inquilinos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditarInquilino(int id, Inquilinos inquilino)
        {
            try
            {
               Repo.Modificar(inquilino);

                return RedirectToAction(nameof(IndexI));
            }
            catch(Exception ex)
            {
                return View();
            }
        }

        // GET: Inquilinos/Delete/5
        public ActionResult BorrarInquilino(int id)
        {
            var inquilino = Repo.ObtenerInquilino(id);
            return View(inquilino);
        }

        // POST: Inquilinos/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult BorrarInquilino(int id, IFormCollection collection)
        {
            try
            {
               Repo.Borrar(id);

                return RedirectToAction(nameof(IndexI));
            }
            catch(Exception ex)
            {
                return View();
            }
        }
    }
}