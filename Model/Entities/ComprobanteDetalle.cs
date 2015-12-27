namespace Model.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ComprobanteDetalle")]
    public partial class ComprobanteDetalle
    {
        public int id { get; set; }

        public int ComprobanteId { get; set; }

        public int ProductoId { get; set; }

        public int Cantidad { get; set; }

        public decimal PrecioUnitario { get; set; }

        public decimal Monto { get; set; }

        public virtual Comprobante Comprobante { get; set; }

        public virtual Producto Producto { get; set; }
    }

    #region ViewModels
    public partial class ComprobanteDetalleViewModel
    {
        public int ProductoId { get; set; }
        public string ProductoNombre { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public bool Retirar { get; set; }
        public decimal Monto()
        {
            return Cantidad * PrecioUnitario;
        }
    }
    #endregion
}