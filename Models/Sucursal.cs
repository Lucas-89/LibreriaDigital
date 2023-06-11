using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace HerrProgLibreriaDigital.Models
{
    public class Sucursal
    {
         public int Id {get;set;}
        // [Display(Nombre="Sucursal")]
        public string NombreSucursal {get;set;}
        public string Direccion {get;set;}
        public int Calificacion{get;set;}
        public string Localidad{get;set;}
        public bool StockPermanente{get;set;}
        public List<Libro> Libros {get;set;} = new List<Libro>();
    }
}