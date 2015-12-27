using Model.BusinessLogic;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Facturador.Controllers
{
    public class HomeController : Controller
    {
        private ComprobanteLogic cl = new ComprobanteLogic();
        private ProductoLogic pl = new ProductoLogic();

        public ActionResult Index()
        {
            return View(cl.Listar());
        }

        public JsonResult BuscarProducto(string nombre)
        {
            return Json(pl.Buscar(nombre));
        }

        public ActionResult Registrar()
        {
            return View(new ComprobanteViewModel());
        }

        [HttpPost]
        public ActionResult Registrar(ComprobanteViewModel model, string action)
        {
            if (action == "generar")
            {
                if (!string.IsNullOrEmpty(model.Cliente))
                {
                    if (cl.Registrar(model.ToModel()))
                    {
                        return Redirect("~/");
                    }
                }
                else {
                    ModelState.AddModelError("cliente", "Debe agregar un cliente para el comprobante");
                }
            }
            else if (action == "agregar_producto")
            {
                // Si no ha pasado nuestra validación, mostramos el mensaje personalizado de error
                if (!model.SeAgregoUnProductoValido())
                {
                    ModelState.AddModelError("producto_agregar", "Solo puede agregar un producto válido al detalle");
                }
                else if (model.ExisteEnDetalle(model.CabeceraProductoId))
                {
                    ModelState.AddModelError("producto_agregar", "El producto elegido ya existe en el detalle");
                }
                else
                {
                    model.AgregarItemADetalle();
                }
            }
            else if (action == "retirar_producto")
            {
                model.RetirarItemDeDetalle();
            }
            else {
                throw new Exception("Acción no definida ..");
            }

            return View(model);
        }

        public ActionResult Detalle(int id)
        {
            return View(cl.Obtener(id));
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}