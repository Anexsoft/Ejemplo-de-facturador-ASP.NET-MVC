using Model.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.BusinessLogic
{
    public class ProductoLogic
    {
        public List<Producto> Buscar(string nombre)
        {
            using (var context = new FacturadorContext())
            {
                context.Configuration.LazyLoadingEnabled = false;
                context.Configuration.ProxyCreationEnabled = false;

                var productos =  context.Producto.OrderBy(x => x.Nombre)
                                        .Where(x => x.Nombre.Contains(nombre))
                                        .Take(10)
                                        .ToList();

                return productos;
            }
        }
    }
}
