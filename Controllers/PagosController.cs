using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Inmobiliaria.Models;

namespace Inmobiliaria.Controllers
{

    public class PagosController : Controller
    {
        private readonly RepositorioContrato RepoContratos;
        private readonly RepositorioPago RepoPagos;

        public PagosController(){
            RepoContratos = new RepositorioContrato();
            RepoPagos = new RepositorioPago();
        }
        // GET: Pagos
        public ActionResult IndexP()
        {
           try{ var listaPagos = RepoPagos.GetPagos();
            return View(listaPagos); }
            catch(Exception ex){
                throw;
            }
        }

        // GET: Pagos/Details/5
        public ActionResult DetallePago(int Id)
        {   
            var pago = RepoPagos.ObtenerPago(Id);
            return View(pago);
        }

        // GET: Pagos/Create
        public ActionResult CrearPago()
        {
            ViewBag.Contrato = RepoContratos.GetContratos();
            return View();
        }

        // POST: Pagos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CrearPago(Pagos pagos)
        {
            try
            {
                int res = RepoPagos.Alta(pagos);
                if(res>0){
                    return RedirectToAction(nameof(IndexP));
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

        // GET: Pagos/Edit/5
        public ActionResult EditarPago(int Id)
        {
            ViewBag.Contrato = RepoContratos.GetContratos();
            var pago = RepoPagos.ObtenerPago(Id);
            return View(pago);
        }

        // POST: Pagos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditarPago(int Id,Pagos pagos)
        {
            try
            {
                
                RepoPagos.Modificar(pagos);
                return RedirectToAction(nameof(IndexP));
            }
            catch(Exception ex)
            {
              throw;
            }
        }

        // GET: Pagos/Delete/5
        public ActionResult BorrarPago(int Id)
        {   var pago = RepoPagos.ObtenerPago(Id);
            return View(pago);
        }

        // POST: Pagos/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult BorrarPago(int Id, IFormCollection collection)
        {
            try
            {
               RepoPagos.Borrar(Id);

                return RedirectToAction(nameof(IndexP));
            }
            catch(Exception ex)
            {
                throw;
            }
        }
    }
}