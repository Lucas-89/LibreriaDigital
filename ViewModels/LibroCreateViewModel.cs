using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HerrProgLibreriaDigital.Models;
using HerrProgLibreriaDigital.Utils;

namespace HerrProgLibreriaDigital.ViewModels
{
    public class LibroCreateViewModel
    {
         public int Id{get;set;}
        public string Titulo {get;set;}
        public string Genero {get;set;}
        public int CantPaginas{get;set;}
        public int AutorId{get;set;}
        //public List<Autor> autores{get;set;} = new List<Autor>();
        public List<int> SucursalElegida {get;set;} =new List<int>();
        public List<Sucursal> Sucursales {get;set;} 
    }
}