using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ListaArtesanal.Models
{
    public class Singleton
    {
        private readonly static Singleton _instance = new Singleton();
        public ListaMedicamento ClientesList;
        public Arbol<MedicamentoIndice> ArbolBinario = new Arbol<MedicamentoIndice>();

        private Singleton()
        {
            ClientesList = new ListaMedicamento();
            ArbolBinario = new Arbol<MedicamentoIndice>();
        }

        public static Singleton Instance
        {
            get
            {
                return _instance;
            }
        }





    }
}
