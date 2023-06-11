using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HerrProgLibreriaDigital.Utils;

namespace HerrProgLibreriaDigital.Models
{
    public class Libro
    {
        public int Id {get;set;}
        public string Titulo {get;set;}
        public TipoGenero Genero {get;set;}
        public int CantPaginas{get;set;}
        public int AutorId{get;set;}
        public virtual Autor Autor{get;set;}
        public List<Sucursal> Sucursales {get;set;} = new List<Sucursal>();
    }
}