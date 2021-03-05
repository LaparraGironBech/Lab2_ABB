using System;
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
        public string Precio { get; set; } //aún tengo dudas
        public int Existencia { get; set; }
        public Medicamento Siguiente { get; set; }

        //Método constructor
        public Medicamento(int id, string nombre, string descripcion, string casa_Productora, string precio, int existencia)
        {
            this.id = id;
            this.nombre = nombre;
            this.descripcion = descripcion;
            Casa_Productora = casa_Productora;
            Precio = precio;
            Existencia = existencia;
            Siguiente = null;
        }

        //Metodos get y set

        //public int getid() { return id; }
        //public void setid(int id) { this.id = id; }

        //public string getnombre() { return nombre; }
        //public void setid(string nombre) { this.nombre = nombre; }

        //public string getdescripcion() { return descripcion; }
        //public void setdescripcion(string descripcion) { this.descripcion = descripcion; }

        //public string getCasa_Productora() { return Casa_Productora; }
        //public void setCasa_Productora(string Casa_Productora) { this.Casa_Productora = Casa_Productora; }

        //public string getPrecioa() { return Precio; }
        //public void setPrecio(string Precio) { this.Precio = Precio; }

        //public int getExistencia() { return Existencia; }
        //public void setExistencia(int Existencia) { this.Existencia = Existencia; }


        //public Medicamento getSiguiente() { return Siguiente; }
        //public void setSiguiente(Medicamento Siguiente) { this.Siguiente = Siguiente; }

    }
}
