using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Tablas
{
    public enum TipoTarjeta
    {
        TDD,
        TDC
    }
    public enum TipoProduto
    {
        VISA, MASTERCARD, AMEX
    }
    [Table("compras")]
    public class TablaCompras : _TablaBase
    {
        [Required]
        public uint ClienteId { get; set; }

        public string? NumeroTarjeta { get; set; }
        public string? Compra { get; set; }
        public double? Monto { get; set; }

        public TipoTarjeta TipoTarjeta { get; set; }
        public TipoProduto TipoProduto { get; set; }
        [ForeignKey(nameof(ClienteId))]
        public virtual TablaClientes? ClientesNavigation { get; set; }
    }
}
