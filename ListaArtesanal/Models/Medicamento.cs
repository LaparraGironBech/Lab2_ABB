using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ListaArtesanal.Models
{
    public class Medicamento //Declaración de nuestro objeto medicamento
    {
        //Declaración de los atributos de nuestro objeto

        public int id { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public string Casa_Productora { get; set; }
        public double Precio { get; set; } //aún tengo dudas
        public int Existencia { get; set; }
      //  public Medicamento Siguiente { get; set; }

        //Método constructor
        public Medicamento(int id, string nombre, string descripcion, string casa_Productora, double precio, int existencia)
        {
            this.id = id;
            this.nombre = nombre;
            this.descripcion = descripcion;
            Casa_Productora = casa_Productora;
            Precio = precio;
            Existencia = existencia;
          //  Siguiente = null;
        }

       

    }
}
