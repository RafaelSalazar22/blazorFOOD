using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto_Food_Blazor.Data 
{
    public class User
    {
        public int IdUser { get; set; }
        [Required(ErrorMessage = "EL Nombre es un campo obligatorio")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "EL Apellido es un campo obligatorio")]
        public string Apellidos { get; set; }
        [Required(ErrorMessage = "EL Dirección es un campo obligatorio")]
        public string Direccion { get; set; }
        [Required(ErrorMessage = "EL Edad es un campo obligatorio")]
        [Range(18, 100,ErrorMessage ="Para poder registrate debes ser mayor de edad tener 18 o más")]
        public int? Edad { get; set; }
        public string Genero { get; set; }
        [RegularExpression("(^[0-9]+$)", ErrorMessage = "Solo se permiten números")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "El número es obligatorio")]
        [StringLength(12, ErrorMessage = "El número es demasiado largo")]
        public string Telefono { get; set; }
        [Required(ErrorMessage = "EL Correo es un campo obligatorio")]
        [EmailAddress]
        public string Correo { get; set; }
        [Required(ErrorMessage = "La Contraseña es un campo obligatorio")]
        [MaxLength(8, ErrorMessage = "Solo puede poner como maximo 8 caracteres")]
        public string Password { get; set; }

  
  
    }
}
