//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Karma.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class DetallesOrdenes
    {
        public int OrdenesID { get; set; }
        public int ProductoID { get; set; }
        public decimal PrecioUnidad { get; set; }
        public short Cantidad { get; set; }
    
        public virtual Ordenes Ordenes { get; set; }
        public virtual Producto Producto { get; set; }
    }
}
