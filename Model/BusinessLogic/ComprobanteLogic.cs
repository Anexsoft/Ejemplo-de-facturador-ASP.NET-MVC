using Model.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Model.BusinessLogic
{
    public class ComprobanteLogic
    {
        public bool Registrar(Comprobante comprobante) {
            try
            {
                using (var context = new FacturadorContext())
                {
                    context.Entry(comprobante).State = EntityState.Added;
                    context.SaveChanges();
                }
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public Comprobante Obtener(int id)
        {
            using (var context = new FacturadorContext())
            {
                // Esta consulta incluye el detalle del comprobante, y el producto que tiene cada comprobante. Me refiero a sus relaciones
                return context.Comprobante.Include(x => x.ComprobanteDetalle.Select(y => y.Producto))
                                          .Where(x => x.id == id)
                                          .SingleOrDefault();
            }
        }

        public List<Comprobante> Listar()
        {
            using (var context = new FacturadorContext())
            {
                return context.Comprobante.OrderByDescending(x => x.Creado)
                                          .ToList();
            }
        }
    }
}
