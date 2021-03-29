using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ListaArtesanal.Models
{
    public class MedicamentoIndice: IComparable
    {
        public int CompareTo(object? obj)
        {
            MedicamentoIndice value = (MedicamentoIndice)obj;            
            return nombre.CompareTo(value.nombre);
        }
        

        public int DevolverLinea()
        {
            return linea;
        }
        public int linea { get; set; } 
        public string nombre { get; set; }

        public MedicamentoIndice(string nombre,int linea)
        {
            this.nombre = nombre;
            this.linea = linea;

        }
    }
}
