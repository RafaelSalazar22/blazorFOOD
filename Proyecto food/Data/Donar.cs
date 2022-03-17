using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto_Food_Blazor.Data
{
    public class Donar
    { 

        public int IdDonativo { get; set; }
        public bool Arroz { get; set; }
        public bool Frijol { get; set; }
        public bool Atun { get; set; }
        public bool GranosElote { get; set; }
        public bool SopaEnlatada { get; set; }
        public bool Champiniones { get; set; }
        public bool LechePolvo { get; set; }
        public bool Sardina { get; set; }
        public string  otro { get; set; }
        public int? IdUser { get; set; }
        [Required(ErrorMessage = "La FechaAcordada es un campo obligatorio")]
        [DataType(DataType.DateTime)]
        public DateTime? FechaAcuerdo { get; set; }
    }
}
