using System;
using System.Collections.Generic;

namespace Ventas.DataAccess.Models;

public partial class DetallesPedido
{
    public decimal IdDetalle { get; set; }

    public decimal IdPedido { get; set; }

    public decimal IdProducto { get; set; }

    public int Cantidad { get; set; }

    public virtual Pedido IdPedidoNavigation { get; set; } = null!;

    public virtual Producto IdProductoNavigation { get; set; } = null!;
}
