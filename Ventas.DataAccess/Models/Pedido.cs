using System;
using System.Collections.Generic;

namespace Ventas.DataAccess.Models;

public partial class Pedido
{
    public decimal IdPedido { get; set; }

    public decimal IdCliente { get; set; }

    public DateTime? FechaPedido { get; set; }

    public decimal Total { get; set; }

    public virtual ICollection<DetallesPedido> DetallesPedidos { get; set; } = new List<DetallesPedido>();

    public virtual Cliente IdClienteNavigation { get; set; } = null!;
}
