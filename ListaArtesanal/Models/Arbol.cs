using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ListaArtesanal.Models
{
    public class Arbol<T> where T : IComparable
    {
        public Hoja<T> raiz { get; set; }
        public int cantidadHojas { get; set; }

        public Arbol()
        {
            raiz = null;
        }
        public void insertArbol(T value)
        {
            Hoja<T> nuevahoja = new Hoja<T>();
            nuevahoja.value = value;
            nuevahoja.hojaIzquierda = null;
            nuevahoja.hojaDerecha = null;
            if (raiz == null)
            {
                raiz = nuevahoja;
                cantidadHojas++;
            }
            else
            {
                Hoja<T> ant = null, pivot;
                pivot = raiz;
                while (pivot != null)
                {
                    ant = pivot;
                    if (nuevahoja.value.CompareTo(pivot.value) > 0)
                    {
                        pivot = pivot.hojaDerecha;
                    }
                    else
                    {
                        pivot = pivot.hojaIzquierda;
                    }
                }
                if (nuevahoja.value.CompareTo(ant.value) > 0)
                {
                    ant.hojaDerecha = nuevahoja;
                }
                else
                {
                    ant.hojaIzquierda = nuevahoja;
                }
                cantidadHojas++;
            }
        }         
    }
}
