using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ListaArtesanal.Models
{
    public class Singleton
    {
        private readonly static Singleton _instance = new Singleton();
        public ListaGenerics<Medicamento> ClientesList;
        public ListaGenerics<MedicamentoIndice> ClientesListIndice;
        public Arbol<MedicamentoIndice> ArbolBinario = new Arbol<MedicamentoIndice>();
        public List<MedicamentoIndice> Lista = new List<MedicamentoIndice>();
        public List<Medicamento> Listaver = new List<Medicamento>();
        public List<Clientesdata> clienteslistadata = new List<Clientesdata>();

        private Singleton()
        {
            ClientesListIndice = new ListaGenerics<MedicamentoIndice>();
            clienteslistadata = new List<Clientesdata>();
            ClientesList = new ListaGenerics<Medicamento>();
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
