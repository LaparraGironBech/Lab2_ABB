using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ListaArtesanal.Models
{
    public class Arbol<T> where T : IComparable
    {
        public Hoja<T> raiz;
        public int cantidadHojas { get; set; }
        bool existe = false;
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
                    if (value.CompareTo(pivot.value) > 0)
                    {
                        pivot = pivot.hojaDerecha;
                    }
                    else
                    {
                        pivot = pivot.hojaIzquierda;
                    }
                }
                if (value.CompareTo(ant.value) > 0)
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
        public bool PreOrden(Hoja<T> r,Hoja<T> medicamento)
        {            
            if (r.value.CompareTo(medicamento) == 0)
            {
                medicamento = r;
                existe = true;                
            }
            else
            {
                if (r.hojaIzquierda != null)
                {
                    PreOrden(r.hojaIzquierda, medicamento);
                }
                if (r.hojaDerecha != null)
                {                  
                        PreOrden(r.hojaDerecha, medicamento);                    
                }
            }
            return existe;            
        }       
    }
}
