using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HerrProgLibreriaDigital.Models;

namespace HerrProgLibreriaDigital.ViewModels
{
    public class AutorViewModel
    {
        public List<Autor> Autores {get;set;} = new List<Autor>();
        public string AutorName {get;set;}
    }
}