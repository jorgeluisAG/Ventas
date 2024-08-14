using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ventas.DTO
{
    public class ClienteDTO
    {
        public decimal IdCliente { get; set; }
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public string CorreoElectronico { get; set; } = null!;
        public DateTime? FechaRegistro { get; set; }
        public List<PedidoDTO> Pedidos { get; set; } = new List<PedidoDTO>();
    }
}
