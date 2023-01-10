using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Tablas
{
    public enum Sexo
    {
        M,F
    }
    [Table("clientes")]
    public class TablaClientes:_TablaBase
    {
        public string? Nombre { get; set; }
        public string? Direccion { get; set; }
        public int? Edad { get; set; }
        public string? Telefono { get; set; }
     
        public Sexo? Sexo { get; set; } 
        public string? CuentaBancaria { get; set; }

        
    }
}
