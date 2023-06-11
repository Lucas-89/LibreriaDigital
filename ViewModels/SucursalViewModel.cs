using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HerrProgLibreriaDigital.Models;

namespace HerrProgLibreriaDigital.ViewModels
{
    public class SucursalViewModel
    {
        public List<Sucursal> Sucursales{get;set;} = new List<Sucursal>();
        public string filterName{get;set;}
    }
}