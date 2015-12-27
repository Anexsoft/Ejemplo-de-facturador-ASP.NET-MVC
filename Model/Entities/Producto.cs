namespace Model.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Producto")]
    public partial class Producto
    {
        public Producto()
        {
            ComprobanteDetalle = new List<ComprobanteDetalle>();
        }

        public int id { get; set; }

        [Required]
        [StringLength(300)]
        public string Nombre { get; set; }

        public decimal Precio { get; set; }

        public virtual List<ComprobanteDetalle> ComprobanteDetalle { get; set; }
    }
}
