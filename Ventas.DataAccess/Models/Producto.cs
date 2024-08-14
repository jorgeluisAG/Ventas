using System;
using System.Collections.Generic;

namespace Ventas.DataAccess.Models;

public partial class Producto
{
    public decimal IdProducto { get; set; }

    public string NombreProducto { get; set; } = null!;

    public decimal Precio { get; set; }

    public int Stock { get; set; }

    public virtual ICollection<DetallesPedido> DetallesPedidos { get; set; } = new List<DetallesPedido>();
}
