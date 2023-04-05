using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Inmobiliaria.Models;

namespace Inmobiliaria.Controllers
{
    public class InmueblesController : Controller
    {
        private readonly RepositorioInmueble RepoInmueble;
        private readonly RepositorioPropietario RepoPropietario;

        public InmueblesController(){
            RepoInmueble = new RepositorioInmueble();
            RepoPropietario = new RepositorioPropietario();
        }

        // GET: Inmuebles
        public ActionResult IndexIn()
        {
            var listaIn=RepoInmueble.GetInmuebles();
            return View(listaIn);
        }

        // GET: Inmuebles/Details/5
        public ActionResult DetalleInmueble(int id)
        {
           
           var inmueble = RepoInmueble.ObtenerInmueble(id);
            return View(inmueble);
        }

        // GET: Inmuebles/Create
        public ActionResult CrearInmueble()

        {   
            try{
                
                ViewBag.Propietarios = RepoPropietario.GetPropietarios();
                return View();

            }
            catch(Exception ex){
                throw;
            }
        
        }

        // POST: Inmuebles/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CrearInmueble(Inmuebles inmuebles)
        {
            try
            {
                int res = RepoInmueble.Alta(inmuebles);
                if(res>0){
                    return RedirectToAction(nameof(IndexIn));
                }
                else{
                    return View();
                }
               
                
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        // GET: Inmuebles/Edit/5
        public ActionResult EditarInmueble(int id)

        {
            ViewBag.Propietarios = RepoPropietario.GetPropietarios();
            var inmueble = RepoInmueble.ObtenerInmueble(id);
            return View(inmueble);
        }

        // POST: Inmuebles/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditarInmueble(int id, Inmuebles inmueble)
        {
            try
            {
               RepoInmueble.Modificar(inmueble);

                return RedirectToAction(nameof(IndexIn));
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        // GET: Inmuebles/Delete/5
        public ActionResult BorrarInmueble(int id)
        {
            var inmueble = RepoInmueble.ObtenerInmueble(id);
            return View(inmueble);
        }

        // POST: Inmuebles/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult BorrarInmueble(int id, IFormCollection collection)
        {
            try
            {
               RepoInmueble.Borrar(id);

                return RedirectToAction(nameof(IndexIn));
            }
            catch(Exception ex)
            {
                return View();
            }
        }
    }
}