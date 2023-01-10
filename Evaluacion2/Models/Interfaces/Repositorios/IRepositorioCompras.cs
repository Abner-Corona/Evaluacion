using Models.Tablas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Interfaces.Repositorios
{
    public interface IRepositorioCompras : _IRepositorioBase<TablaCompras>
    {
        public Task<IList<TablaCompras>> GetByClientId(uint clientId);
    }
}
