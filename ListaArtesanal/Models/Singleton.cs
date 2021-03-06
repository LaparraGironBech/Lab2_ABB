using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ListaArtesanal.Models
{
    public class Singleton
    {
        private readonly static Singleton _instance = new Singleton();
        public List<Clientesdata> ClientesList;
        private Singleton()
        {
            ClientesList = new List<Clientesdata>();
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
