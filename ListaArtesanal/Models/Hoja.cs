using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ListaArtesanal.Models
{
    public class Hoja<T>
    {
        //public int linea { get; set; } 
        //public string nombre { get; set; }
        public T value { get; set; }
        public Hoja<T> hojaIzquierda { get; set; }
        public Hoja<T> hojaDerecha { get; set; }
        
        public Hoja()
        {
            hojaIzquierda = null;
            hojaDerecha = null;
           // linea = 0;
           // nombre = ""; 
           
        }
    }
}
