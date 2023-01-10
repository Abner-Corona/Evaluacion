using Models.Tablas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Models.Dtos
{
    public class ClientesDto
    {
        public uint Id { get; set; }
        public string? Nombre { get; set; }
        public string? Direccion { get; set; }
        public int? Edad { get; set; }
        public string? Telefono { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public Sexo? Sexo { get; set; }
        public string? CuentaBancaria { get; set; }
    }
}
