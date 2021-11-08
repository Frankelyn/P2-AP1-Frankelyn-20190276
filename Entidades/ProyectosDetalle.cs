using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2_AP1_Frankelyn_20190276.Entidades
{
    public class ProyectosDetalle
    {
        [Key]
        public int ProyectoDetalleId { get; set; }
        public int ProyectoId { get; set; }
        public int TipoDeTareaId { get; set; }
        public string Requerimiento { get; set; }
        public int Tiempo { get; set; }

        [ForeignKey("TipoDeTareaId")]
        public virtual TipoDeTarea TipoDeTarea { get; set;}
    }
}
