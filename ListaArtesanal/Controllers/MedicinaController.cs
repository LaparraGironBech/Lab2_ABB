﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using ListaArtesanal.Models;
namespace ListaArtesanal.Controllers
{
    
    public class MedicinaController : Controller
    {
        ListaMedicamento ListMedicina = new ListaMedicamento();
        Arbol ArbolBinario = new Arbol();
      
       
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
        public IActionResult IndexVer()
        {
            return View(ListMedicina);
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
                                Medicamento NodoMedicamento = new Medicamento(Convert.ToInt32(NodoM[0]),NodoM[1], NodoM[2], NodoM[3], NodoM[4],Convert.ToInt32(NodoM[5]));
                                ListMedicina.AgregarFinal(NodoMedicamento);

                               

                            }
                        }
                    }
                }
                

                //return  View(dt);
                for (int i = 0; i < 1000; i++)
                {
                    ArbolBinario.insertarArbol(ListMedicina.ObtenerPos(i).nombre, i + 1);
                }
                return RedirectToAction(nameof(IndexVer));
            }
            

            return View();
          
        }
    }
}