using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ListaArtesanal.Models
{
    public class Arbol
    {
        public int id {get; set; }
        public int cantT { get; set; }
        public bool comprobador { get; set; }
        public int cantidadRecorridos { get; set; }
        public Hoja raiz { get; set; }
        public int cantidadHojas { get; set; }
        

        public Arbol()
        {
            comprobador = false;
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
                //adfafasdfas
                //Jason se la come
            }            
        }

        public void Busqueda_PreOrden(Hoja raiz, string nombreProducto)
        {
            cantidadRecorridos++;
            if (raiz.nombre == nombreProducto)
            {
                id = raiz.linea;
                comprobador = true;
                cantT = cantidadRecorridos;                
            }
            else
            {
                if (raiz.hojaIzquierda != null)
                    Busqueda_PreOrden(raiz.hojaIzquierda, nombreProducto);
                if (raiz.hojaDerecha != null)
                    Busqueda_PreOrden(raiz.hojaDerecha, nombreProducto);
            }           
        }
       
    }
}
