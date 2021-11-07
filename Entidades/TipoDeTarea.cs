using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2_AP1_Frankelyn_20190276.Entidades
{
    public class TipoDeTarea
    {
        [Key]
        public int TipoDeTareaId { get; set; }
        public string Descripcion { get; set; }
        public int TiempoAcumulado { get; set; }
    }
}
