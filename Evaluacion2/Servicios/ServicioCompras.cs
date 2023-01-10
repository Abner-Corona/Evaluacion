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
    public class ServicioCompras : IServicioCompras
    {
        private IRepositorioCompras _repositorioCompras;
        public ServicioCompras(IRepositorioCompras repositorioCompras)
        {
            _repositorioCompras = repositorioCompras;
        }
        public async Task<IList<ComprasDto>> GetByClientId(uint clientId)
        {
            try
            {
                var compras = await _repositorioCompras.GetByClientId(clientId);
                var res = compras.Adapt<IList<ComprasDto>>();
                return res;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
