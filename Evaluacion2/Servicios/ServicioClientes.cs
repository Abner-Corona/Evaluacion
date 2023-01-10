using Mapster;
using Models.Dtos;
using Models.Interfaces.Repositorios;
using Models.Interfaces.Servicios;
using RepositorioEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public class ServicioClientes : IServicioClientes
    {
        private IRepositorioClientes _repositorioClientes;
        public ServicioClientes(IRepositorioClientes repositorioClientes)
        {
            _repositorioClientes = repositorioClientes;
        }
        public async Task<IList<ClientesDto>> GetAllAsync()
        {
			try
			{
                var clientes = await _repositorioClientes.GetAllAsync();
                var res = clientes.Adapt<IList<ClientesDto>>();
                return res;
            }
			catch (Exception ex)
			{

				throw;
			}
        }
    }
}
