using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ListaArtesanal.Models
{
    public class ListaMedicamento
    {
        public Medicamento PrimerMedicamento;
        public Medicamento UltimoMedicamento;
        public int Cantidad;
        

        //Metodos
        public void AgregarInicio(Medicamento Nom1 )
        {
            if (Cantidad==0)
            {
                PrimerMedicamento = Nom1;
                UltimoMedicamento = Nom1;
            }
            else
            {
                Medicamento temp = Nom1;
                temp.Siguiente = PrimerMedicamento;
                PrimerMedicamento = temp;
            }
            Cantidad++;
        }

        public void AgregarFinal(Medicamento Nom2)
        {
            if(Cantidad==0)
            {
                AgregarInicio(Nom2);
            }
            else
            {
                UltimoMedicamento.Siguiente = Nom2;
                UltimoMedicamento = Nom2;
            }
            Cantidad++;
        }

        public void AgregarPos(int pos, Medicamento Nom3)
        {
            if(Cantidad==0 || pos==0)
            {
                AgregarInicio(Nom3);
            }
            else
            {
                Medicamento pretemp = PrimerMedicamento;
                Medicamento temp = Nom3;
                int cont = 0;

                while(cont < (pos-1))
                {
                    pretemp = pretemp.Siguiente;
                    cont++;
                }
                temp.Siguiente = pretemp.Siguiente;
                pretemp.Siguiente = temp;
                Cantidad++;
            }
        }

          
        public Medicamento ObtenerInicio()
        {
            return PrimerMedicamento;
        }

        public Medicamento ObtenerFinal()
        {
            return UltimoMedicamento;
        }

        public Medicamento ObtenerPos(int Pos)
        {
            if(Cantidad== 0 ||Pos==0)
            {
                return ObtenerInicio();
            }
            else
                if(Pos>=Cantidad)
            {
                return ObtenerFinal();
            }
            else
            {
                Medicamento temp = PrimerMedicamento;
                int cont = 0;
                while(cont<Pos)
                {
                    temp = temp.Siguiente;
                    cont++;
                }
                return temp;
            }


        }
    
    }
}
