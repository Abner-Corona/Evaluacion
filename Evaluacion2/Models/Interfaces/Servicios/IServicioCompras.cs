using Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Interfaces.Servicios
{
    public interface IServicioCompras
    {
        public Task<IList<ComprasDto>> GetByClientId(uint clientId);
    }
}
