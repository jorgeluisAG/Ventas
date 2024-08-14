using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ventas.DTO
{
    public class DetallesPedidoDTO
    {
        public decimal IdDetalle { get; set; }
        public decimal IdPedido { get; set; }
        public decimal IdProducto { get; set; }
        public int Cantidad { get; set; }
        public PedidoDTO? Pedido { get; set; }
        //public ProductoDTO? Producto { get; set; }
    }
}
