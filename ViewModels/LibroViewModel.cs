using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HerrProgLibreriaDigital.Models;
using HerrProgLibreriaDigital.Utils;

namespace HerrProgLibreriaDigital.ViewModels
{
    public class LibroViewModel
    {
        public List<Libro> Libros {get;set;} = new List<Libro>();
        public string LibroName {get;set;}
        
    }
}