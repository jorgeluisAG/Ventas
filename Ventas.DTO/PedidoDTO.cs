using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ventas.DTO
{
    public class PedidoDTO
    {
        public decimal IdPedido { get; set; }
        public decimal IdCliente { get; set; }
        public DateTime? FechaPedido { get; set; }
        public decimal Total { get; set; }
        public List<DetallesPedidoDTO> DetallesPedidos { get; set; } = new List<DetallesPedidoDTO>();
        public ClienteDTO? Cliente { get; set; }
    }
}
