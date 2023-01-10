using Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace Models.Interfaces.Servicios
{
    public interface IServicioClientes
    {
        public Task<IList<ClientesDto>> GetAllAsync();
    }
}
