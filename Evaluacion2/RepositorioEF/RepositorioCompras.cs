using Microsoft.EntityFrameworkCore;
using Models.Interfaces.Repositorios;
using Models.Tablas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositorioEF
{
    public class RepositorioCompras : _RepositorioBase<TablaCompras>, IRepositorioCompras
    {
        public RepositorioCompras(_DatabaseContext context) : base(context)
        {
        }

        public async Task<IList<TablaCompras>> GetByClientId(uint clientId)
        {
            var entity = _context.Compras.AsQueryable();
            return await entity.Where(i => i.ClienteId == clientId).ToListAsync();
        }
    }
}
