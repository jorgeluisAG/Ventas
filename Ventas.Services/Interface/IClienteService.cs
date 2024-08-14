using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ventas.DataAccess.Models;

namespace Ventas.Services.Interface
{
    public interface IClienteService
    {
        Task<RespuestaService<List<Cliente>>> Lists();
        Task<RespuestaService<Cliente>> ClienteById(decimal id);
        Task<RespuestaService<Cliente>> SaveCliente(Cliente c);
        Task<RespuestaService<Cliente>> UpdateCliente(Cliente c);
        Task<RespuestaService<bool>> DeleteCliente(decimal id);
    }
}
