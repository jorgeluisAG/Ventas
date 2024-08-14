using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ventas.DataAccess.Models;
using Ventas.Services.Interface;

namespace Ventas.Services.Implementation
{
    public class ClienteService : IClienteService
    {
        private ModelContext _modelContext;

        public ClienteService(ModelContext modelContext)
        {
            _modelContext = modelContext;
        }
        public async Task<RespuestaService<Cliente>> ClienteById(decimal id)
        {
            var res = new RespuestaService<Cliente>();
            var cat = await _modelContext.Clientes.FirstOrDefaultAsync(x => x.IdCliente == id);

            if (cat == null)
                res.AgregarBadRequest("El id recibido no está registrado");
            else
                res.Objeto = cat;

            return res;
        }

        public async Task<RespuestaService<bool>> DeleteCliente(decimal id)
        {
            var res = new RespuestaService<bool>();
            var cat = await _modelContext.Clientes.FirstOrDefaultAsync(x => x.IdCliente == id);

            if (cat == null)
                res.AgregarBadRequest("El id recibido no está registrado");
            else
            {
                try
                {
                    _modelContext.Clientes.Remove(cat);
                    await _modelContext.SaveChangesAsync();
                    res.Exito = true;
                }
                catch (DbUpdateException ex)
                {
                    res.AgregarInternalServerError(ex.Message);
                }
            }

            return res;
        }

        public async Task<RespuestaService<List<Cliente>>> Lists()
        {
            var res = new RespuestaService<List<Cliente>>();
            var lista = await _modelContext.Clientes.ToListAsync();

            if (lista != null)
                res.Objeto = lista;
            else
                res.AgregarInternalServerError("Se encontró un error");

            return res;
        }

        public async Task<RespuestaService<Cliente>> SaveCliente(Cliente c)
        {
            var res = new RespuestaService<Cliente>();

            try
            {
                await _modelContext.Clientes.AddAsync(c);
                await _modelContext.SaveChangesAsync();
                c.IdCliente = await _modelContext.Clientes.MaxAsync(u => u.IdCliente);

                res.Objeto = c;
            }
            catch (DbUpdateException ex)
            {
                res.AgregarInternalServerError(ex.Message);
            }

            return res;
        }

        public async Task<RespuestaService<Cliente>> UpdateCliente(Cliente c)
        {
            var res = new RespuestaService<Cliente>();
            var cat = await _modelContext.Clientes.FirstOrDefaultAsync(x => x.IdCliente == c.IdCliente);
            
            if (cat == null)
                res.AgregarBadRequest("El id recibido no está registrado");
            else
            {
                cat.Nombre = c.Nombre;

                try
                {
                    _modelContext.Clientes.Update(cat);
                    await _modelContext.SaveChangesAsync();

                    res.Objeto = cat;
                }
                catch (DbUpdateException ex)
                {
                    res.AgregarInternalServerError(ex.Message);
                }
            }

            return res;
        }


    }
}
