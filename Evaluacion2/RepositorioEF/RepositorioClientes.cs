using Models.Interfaces.Repositorios;
using Models.Tablas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositorioEF
{
    public class RepositorioClientes : _RepositorioBase<TablaClientes>, IRepositorioClientes
    {
        public RepositorioClientes(_DatabaseContext context) : base(context)
        {
        }
    }
}
