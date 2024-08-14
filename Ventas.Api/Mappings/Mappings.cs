using Ventas.DataAccess.Models;
using Ventas.DTO;

namespace Ventas.Api.Mappings
{
    public static partial class Mapper
    {
        // Método para convertir de Cliente a ClienteDTO
        public static ClienteDTO ToDTO(this Cliente model)
        {
            return new ClienteDTO()
            {
                IdCliente = model.IdCliente,
                Nombre = model.Nombre,
                Apellido = model.Apellido,
                CorreoElectronico = model.CorreoElectronico,
                FechaRegistro = model.FechaRegistro,
                Pedidos = model.Pedidos.Select(p => p.ToDTO()).ToList() // Mapea cada Pedido a PedidoDTO
            };
        }

        // Método para convertir de ClienteDTO a Cliente
        public static Cliente ToDatabase(this ClienteDTO dto)
        {
            return new Cliente()
            {
                IdCliente = dto.IdCliente,
                Nombre = dto.Nombre,
                Apellido = dto.Apellido,
                CorreoElectronico = dto.CorreoElectronico,
                FechaRegistro = dto.FechaRegistro,
                Pedidos = dto.Pedidos.Select(p => p.ToDatabase()).ToList() // Mapea cada PedidoDTO a Pedido
            };
        }

        // Método para convertir de Pedido a PedidoDTO
        public static PedidoDTO ToDTO(this Pedido model)
        {
            return new PedidoDTO()
            {
                IdPedido = model.IdPedido,
                IdCliente = model.IdCliente,
                FechaPedido = model.FechaPedido,
                Total = model.Total,
                DetallesPedidos = model.DetallesPedidos.Select(d => d.ToDTO()).ToList(),
                Cliente = model.IdClienteNavigation?.ToDTO()
            };
        }

        // Método para convertir de PedidoDTO a Pedido
        public static Pedido ToDatabase(this PedidoDTO dto)
        {
            return new Pedido()
            {
                IdPedido = dto.IdPedido,
                IdCliente = dto.IdCliente,
                FechaPedido = dto.FechaPedido,
                Total = dto.Total,
                DetallesPedidos = dto.DetallesPedidos.Select(d => d.ToDatabase()).ToList(),
                IdClienteNavigation = dto.Cliente?.ToDatabase()
            };
        }

        // Método para convertir de DetallesPedido a DetallesPedidoDTO
        public static DetallesPedidoDTO ToDTO(this DetallesPedido model)
        {
            return new DetallesPedidoDTO()
            {
                IdDetalle = model.IdDetalle,
                IdPedido = model.IdPedido,
                IdProducto = model.IdProducto,
                Cantidad = model.Cantidad,
                Pedido = model.IdPedidoNavigation?.ToDTO(), // Mapea Pedido
                //Producto = model.IdProductoNavigation?.ToDTO() // Mapea Producto
            };
        }

        // Método para convertir de DetallesPedidoDTO a DetallesPedido
        public static DetallesPedido ToDatabase(this DetallesPedidoDTO dto)
        {
            return new DetallesPedido()
            {
                IdDetalle = dto.IdDetalle,
                IdPedido = dto.IdPedido,
                IdProducto = dto.IdProducto,
                Cantidad = dto.Cantidad,
                IdPedidoNavigation = dto.Pedido?.ToDatabase(), // Mapea Pedido
                //IdProductoNavigation = dto.Producto?.ToDatabase() // Mapea Producto
            };
        }
    }
}
