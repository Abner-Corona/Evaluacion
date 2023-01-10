using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Tablas
{
    public class _TablaBase
    {
       
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public uint Id { get; set; }

        [Column("Activo", TypeName = "tinyint")]
        [DefaultValue(true)]
        public bool Activo { get; set; } = true;
        [Column("FechaCreacion", TypeName = "datetime"), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime FechaCreacion { get; set; } = DateTime.Now;
        [Column("FechaModificacion", TypeName = "datetime"), DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [DefaultValue(null)]
        public DateTime? FechaModificacion { get; set; } = null;

    }

}
