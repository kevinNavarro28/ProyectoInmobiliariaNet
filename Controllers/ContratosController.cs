using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Inmobiliaria.Models;

namespace Inmobiliaria.Controllers

{
   
    public class ContratosController : Controller
    {
    private readonly RepositorioContrato RepoContratos;
    private readonly RepositorioInmueble RepoInmueble;
    private readonly RepositorioInquilino RepoInquilino;

    public ContratosController(){
        RepoContratos = new RepositorioContrato();
        RepoInmueble = new RepositorioInmueble();
        RepoInquilino = new RepositorioInquilino();

    }
        // GET: Contratos
        public ActionResult IndexC()

        { var listaContratos = RepoContratos.GetContratos();
                ViewBag.Inmuebles = RepoInmueble.GetInmuebles();
                ViewBag.Inquilinos =RepoInquilino.GetInquilinos();

            return View(listaContratos);
        }

        // GET: Contratos/Details/5
        public ActionResult DetalleContrato(int id)
        {
            var contrato = RepoContratos.ObtenerContrato(id);
            return View(contrato);
        }

        // GET: Contratos/Create
        public ActionResult CrearContrato()

        {   
            try{
                
                ViewBag.Inmuebles = RepoInmueble.GetInmuebles();
                ViewBag.Inquilinos =RepoInquilino.GetInquilinos();

                return View();

            }
            catch(Exception ex){
                throw;
            }
        
        }

        // POST: Contratos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CrearContrato(Contratos contratos)
        {
            try
            {
                int res = RepoContratos.Alta(contratos);
                if(res>0){
                    return RedirectToAction(nameof(IndexC));
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

        // GET: Contratos/Edit/5
        public ActionResult EditarContrato(int id)
        {       ViewBag.Inmuebles = RepoInmueble.GetInmuebles();
                ViewBag.Inquilinos =RepoInquilino.GetInquilinos();
                var contrato = RepoContratos.ObtenerContrato(id);

            return View(contrato);
        }

        // POST: Contratos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditarContrato(int id, Contratos contratos)
        {
           try
            {
               RepoContratos.Modificar(contratos);

                return RedirectToAction(nameof(IndexC));
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        // GET: Contratos/Delete/5
        public ActionResult BorrarContrato(int id)
        {
            var contrato = RepoContratos.ObtenerContrato(id);
            return View(contrato);
        }

        // POST: Contratos/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult BorrarContrato(int id, IFormCollection collection)
        {
           try
            {
               RepoContratos.Borrar(id);

                return RedirectToAction(nameof(IndexC));
            }
            catch(Exception ex)
            {
                throw;
            }
        }
    }
}