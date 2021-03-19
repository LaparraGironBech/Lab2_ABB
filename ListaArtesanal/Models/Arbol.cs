using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ListaArtesanal.Models
{
    public class Arbol<T> where T: IComparable
    {
        public Hoja<T> raiz { get; set; }
        public int cantidadHojas { get; set; }

        public Arbol()
        {
            raiz = null;
        }
        public void instertArbol(T value)
        {
            Hoja<T> nuevahoja = new Hoja<T>();
            nuevahoja.value = value;
        }
        public void insertarArbol(string nombre, int linea)
        {
            Hoja<T> nuevaHoja = new Hoja<T>();
           // nuevaHoja.nombre = nombre;
           // nuevaHoja.linea = linea;
            nuevaHoja.hojaIzquierda = null;
            nuevaHoja.hojaDerecha = null;

            if (raiz == null)
            {
                raiz = nuevaHoja;
                cantidadHojas++;
            }
            else
            {
                Hoja<T> ant = null, pivot;
                pivot = raiz;
                while(pivot != null)
                {
                    ant = pivot;
                    if (nuevaHoja.value.CompareTo(pivot.value) > 0)
                    {
                        pivot = pivot.hojaDerecha;                        
                    }
                    else
                    {
                        pivot = pivot.hojaIzquierda;                       
                    }                                      
                }
                if (nuevaHoja.value.CompareTo(ant.value) > 0)
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
