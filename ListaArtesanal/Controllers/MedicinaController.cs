using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using ListaArtesanal.Models;
using Microsoft.AspNetCore.Routing;
using SelectPdf;

namespace ListaArtesanal.Controllers
{
    

    public class MedicinaController : Controller
    {
       
        //Cargar archivo CSV
        private IHostingEnvironment Environment;
        public MedicinaController(IHostingEnvironment _environment)
        {
            Environment = _environment;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult totalpedidos()
        {

            return View(Singleton.Instance.clienteslistadata);
            
        }
        public ActionResult MenuPrincipal()
        {
            return View();

        }
        
        public IActionResult IndexVer()
        {
            return View();

        }
        //GET: MedicinaController/Hacerpedido
        public ActionResult Hacerpedido()
        {
            return View();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Hacerpedido(IFormCollection collection)
        {            
            try
            {
                var newPedido = new Models.Clientesdata
                {
                    NIT = Convert.ToInt32(collection["NIT"]),
                    Cantidadmedicamento = Convert.ToInt32(collection["Cantidadmedicamento"]),
                    Name = collection["Name"],
                    Apellido = collection["Apellido"],
                    NombreMedicamento = collection["NombreMedicamento"],
                    FechaDeCompra = Convert.ToString( DateTime.Now.ToShortDateString())

                };                
                
                Hoja<MedicamentoIndice> hojaComparer =new Hoja<MedicamentoIndice>();                
                MedicamentoIndice medicamentoComparer = new MedicamentoIndice(newPedido.NombreMedicamento,1);
                hojaComparer.value = medicamentoComparer;
                bool siExiste = false;
                Singleton.Instance.ArbolBinario.PreOrden(Singleton.Instance.ArbolBinario.raiz,ref hojaComparer,ref siExiste);
                MedicamentoIndice buscador = hojaComparer.value;
                int lineaDeBusqueda = buscador.linea-1;
                double total_a_pagar = 0; ;
                if (siExiste == false)
                {
                    ModelState.AddModelError("NombreMedicamento", "Producto no encontrado");
                    newPedido.NombreMedicamento = "";
                    return View(newPedido);
                    //no existe el medicamento

                }
                else
                {
                    if (Singleton.Instance.ClientesList.ObtenerPos(lineaDeBusqueda).Data.Existencia > 0 && newPedido.Cantidadmedicamento <= Singleton.Instance.ClientesList.ObtenerPos(lineaDeBusqueda).Data.Existencia)
                    {
                        Singleton.Instance.clienteslistadata.Add(newPedido);
                        total_a_pagar = Math.Round(((Singleton.Instance.ClientesList.ObtenerPos(lineaDeBusqueda).Data.Precio) * Convert.ToDouble(newPedido.Cantidadmedicamento)),2);
                        Singleton.Instance.ClientesList.ObtenerPos(lineaDeBusqueda).Data.Existencia = Singleton.Instance.ClientesList.ObtenerPos(lineaDeBusqueda).Data.Existencia - newPedido.Cantidadmedicamento;
                        Singleton.Instance.Listaver[lineaDeBusqueda].Existencia = Singleton.Instance.ClientesList.ObtenerPos(lineaDeBusqueda).Data.Existencia;                       
                        newPedido.cantidadpagar = total_a_pagar;
                    }
                    else
                    {
                        if(Singleton.Instance.ClientesList.ObtenerPos(lineaDeBusqueda).Data.Existencia > 0)
                        {
                            ModelState.AddModelError("Cantidadmedicamento", "Cantidad superior a la existencia"+"\nSolamente se cuenta con "+ Singleton.Instance.ClientesList.ObtenerPos(lineaDeBusqueda).Data.Existencia+" U.");                    
                            return View(newPedido);
                          
                        }
                        else
                        {
                            //alerta que no hay medicamento y hay que reabastecer

                            ModelState.AddModelError("Cantidadmedicamento", "Producto agotado");
                            Random rand = new Random();
                            Singleton.Instance.ClientesList.ObtenerPos(lineaDeBusqueda).Data.Existencia = rand.Next(1,15);
                            Singleton.Instance.Listaver[lineaDeBusqueda].Existencia = Singleton.Instance.ClientesList.ObtenerPos(lineaDeBusqueda).Data.Existencia;
                            return View(newPedido);
                        }

                    }
                }
                return RedirectToAction("Factura", new RouteValueDictionary(new { Controller = "Medicina", Action = "Factura",  Apellido=newPedido.Apellido,  Nombre=newPedido.Name,  Nit=newPedido.NIT,  NMed=newPedido.NombreMedicamento,  CMed= newPedido.Cantidadmedicamento,  TPagar=newPedido.cantidadpagar, Fecha = newPedido.FechaDeCompra }));

                //return RedirectToAction(nameof(totalpedidos));
            }
            catch
            {
                return View();
            }

        }
       


        [HttpPost]
        
        public IActionResult Index(IFormFile postedFile)
        {
            if (postedFile != null)
            {
                string path = Path.Combine(this.Environment.WebRootPath, "Uploads");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                string fileName = Path.GetFileName(postedFile.FileName);
                string filePath = Path.Combine(path, fileName);
                using (FileStream stream = new FileStream(filePath, FileMode.Create))
                {
                    postedFile.CopyTo(stream);
                }
                string csvData = System.IO.File.ReadAllText(filePath);
                DataTable dt = new DataTable();
                bool firstRow = true;
                foreach (string row in csvData.Split('\n'))
                {
                    if (!string.IsNullOrEmpty(row))
                    {
                        if (!string.IsNullOrEmpty(row))
                        {
                            if (firstRow)
                            {

                                foreach (string cell in row.Split(','))
                                {

                                    //dt.Columns.Add(cell.Trim());

                                }

                                firstRow = false;
                            }
                            else
                            {
                                //dt.Rows.Add();
                                int i = 0;
                                int cont = 0;
                                string[] NodoM = new string[6] { "","","", "", "", ""};
                                int encontrar = 0;
                                string cell2 = "";
                                foreach (string cell in row.Split(','))
                                {
                                    if (cell.Substring(0, 1) != "\"" && encontrar == 0)
                                    {
                                        //dt.Rows[dt.Rows.Count - 1][i] = cell.Trim();
                                        NodoM[cont] = cell.Trim();
                                        cell2 = "";
                                        cont++;
                                        i++;
                                    }
                                    else
                                    {
                                        cell2 = cell2 + cell + ", "; encontrar++;
                                        if (cell.Substring((cell.Length - 1), 1) == "\"")
                                        {
                                            encontrar = 0;
                                            cell2 = cell2.Remove(0, 1);
                                            cell2 = cell2.Remove(cell2.Length - 3, 3);
                                            //dt.Rows[dt.Rows.Count - 1][i] = cell2.Trim();
                                            NodoM[cont] = cell2.Trim();
                                            cont++;
                                            i++;
                                            cell2 = "";
                                        }

                                    }
                                }
                                Medicamento NodoMedicamento = new Medicamento(Convert.ToInt32(NodoM[0]),NodoM[1], NodoM[2], NodoM[3],Convert.ToDouble(NodoM[4].Remove(0,1)),Convert.ToInt32(NodoM[5]));                                
                                Singleton.Instance.ClientesList.AgregarFinal(NodoMedicamento);
                                MedicamentoIndice NodoIndice = new MedicamentoIndice(NodoM[1], Convert.ToInt32(NodoM[0]));
                                Singleton.Instance.ClientesListIndice.AgregarFinal(NodoIndice);
                                Singleton.Instance.Listaver.Add(NodoMedicamento);

                            }
                        }
                    }
                }
                

                //return  View(dt);
                for (int i = 0; i < 1000; i++)
                {
                    Singleton.Instance.ArbolBinario.insertArbol(Singleton.Instance.ClientesListIndice.ObtenerPos(i).Data);                     
                }
                return RedirectToAction(nameof(MenuPrincipal));
            }
            

            return View();
          
        }
        public ActionResult Factura(string Apellido, String Nombre, int Nit, String NMed,int CMed, double TPagar, string Fecha)
        {
            Clientesdata Med = new Clientesdata();
            Med.Apellido = Apellido;
            Med.Name = Nombre;
            Med.NIT = Nit;
            Med.NombreMedicamento = NMed;
            Med.Cantidadmedicamento = CMed;
            Med.cantidadpagar =  TPagar;
            Med.FechaDeCompra = Fecha;
            return View(Med);

        }


        public ActionResult VerFarmacos(string Medicamento)
        {
            if(Medicamento==null || Medicamento=="")
            {
                return View(Singleton.Instance.Listaver);
            }
            else
            {
                Hoja<MedicamentoIndice> hojaComparer = new Hoja<MedicamentoIndice>();
                MedicamentoIndice medicamentoComparer = new MedicamentoIndice(Medicamento, 1);
                hojaComparer.value = medicamentoComparer;
                bool siExiste = false;
                Singleton.Instance.ArbolBinario.PreOrden(Singleton.Instance.ArbolBinario.raiz, ref hojaComparer, ref siExiste);
                MedicamentoIndice buscador = hojaComparer.value;
                int lineaDeBusqueda = buscador.linea - 1;
                if (siExiste == false)
                {
                    
                    
                    ModelState.AddModelError("Medicamento", "Producto no encontrado");
                 //  Medicamento = "";
                    return View(Singleton.Instance.Listaver);
                    //no existe el medicamento

                }
                else
                {
                    List<Medicamento> ListaBuscar = new List<Medicamento>();
                    ListaBuscar.Add(Singleton.Instance.Listaver[lineaDeBusqueda]);
                    Medicamento = "";
                   // Reabastecer(lineaDeBusqueda);
                    return View(ListaBuscar);
                }
                

            }
            
        }
        
        public IActionResult Reabastecer(String button)
        {
            int lineaDeBusqueda = (Convert.ToInt32(button)-1);
            Random rand = new Random();
            Singleton.Instance.ClientesList.ObtenerPos(lineaDeBusqueda).Data.Existencia = Singleton.Instance.ClientesList.ObtenerPos(lineaDeBusqueda).Data.Existencia+ rand.Next(1, 15);
            Singleton.Instance.Listaver[lineaDeBusqueda].Existencia = Singleton.Instance.ClientesList.ObtenerPos(lineaDeBusqueda).Data.Existencia;
            //   VerFarmacos (Singleton.Instance.Listaver[lineaDeBusqueda].nombre));
            return RedirectToAction("VerFarmacos", new RouteValueDictionary(new { Controller = "Medicina", Action = "VerFarmacos", Medicamento = Singleton.Instance.Listaver[lineaDeBusqueda].nombre }));
        //   return RedirectToAction(nameof(VerFarmacos)); 
        }
       
    }
}
