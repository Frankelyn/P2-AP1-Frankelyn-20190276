using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2_AP1_Frankelyn_20190276.Entidades
{
    public class Proyectos
    {
        [Key]
        public int ProyectoId { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Now;

        public string Descripcion { get; set; }

        public int TiempoTotal { get; set; }

       // [ForeignKey("ProyectoId")]
        //public virtual List<ProyectoDetalle> Detalle { get; set; } = new List<ProyectoDetalle>(); 
    }
}
