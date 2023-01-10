using Models.Tablas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Models.Dtos
{
    public class ComprasDto
    {
        public uint ClienteId { get; set; }

        public string? NumeroTarjeta { get; set; }
        public string? Compra { get; set; }
        public double? Monto { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public TipoTarjeta TipoTarjeta { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public TipoProduto TipoProduto { get; set; }
    }
}
