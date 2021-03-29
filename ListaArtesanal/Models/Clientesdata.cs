using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace ListaArtesanal.Models
{
    public class Clientesdata
    {
        [Required(ErrorMessage = "Debe ingresar un apellido")]
        public string Apellido { get; set; }
        [Required(ErrorMessage = "Debe ingresar un Nombre")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Debe ingresar un NIT")]
        [StringLength(8)]
        public int NIT { get; set; }
        [Required(ErrorMessage = "Debe ingresar un nombre de medicina")]
        public string NombreMedicamento { get; set; }
        [Required(ErrorMessage = "Debe ingresar una cantidad de medicina")]
        public int Cantidadmedicamento { get; set; }
        public double cantidadpagar { get; set; }
    }
}
