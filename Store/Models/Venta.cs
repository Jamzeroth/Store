//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Store.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Venta
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Venta()
        {
            this.DetalleVenta = new HashSet<DetalleVenta>();
        }
    
        public int id_ven { get; set; }
        public string numeracion_ven { get; set; }
        public int id_usu { get; set; }
        public int id_ped { get; set; }
        public System.DateTime fecha_ven { get; set; }
        public double subtotal_ven { get; set; }
        public double iva_ven { get; set; }
        public double total_ven { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DetalleVenta> DetalleVenta { get; set; }
        public virtual Pedido Pedido { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
