using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ListaArtesanal.Models
{
    public class Arbol
    {
        public Hoja raiz { get; set; }
        public int cantidadHojas { get; set; }

        public Arbol()
        {
            raiz = null;
        }

        public void insertarArbol(string nombre, int linea)
        {
            Hoja nuevaHoja = new Hoja();
            nuevaHoja.nombre = nombre;
            nuevaHoja.linea = linea;
            nuevaHoja.hojaIzquierda = null;
            nuevaHoja.hojaDerecha = null;

            if (raiz == null)
            {
                raiz = nuevaHoja;
                cantidadHojas++;
            }
            else
            {
                Hoja ant = null, pivot;
                pivot = raiz;
                while(pivot != null)
                {
                    ant = pivot;
                    if (nombre.CompareTo(pivot.nombre) > 0)
                    {
                        pivot = pivot.hojaDerecha;                        
                    }
                    else
                    {
                        pivot = pivot.hojaIzquierda;                       
                    }                                      
                }
                if (nombre.CompareTo(ant.nombre) > 0)
                {
                    ant.hojaDerecha = nuevaHoja;
                }
                else
                {
                    ant.hojaIzquierda = nuevaHoja;
                }
                cantidadHojas++;
                //Laparra le gusta comer
            }            
        }
       
    }
}
