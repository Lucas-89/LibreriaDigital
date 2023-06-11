using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HerrProgLibreriaDigital.Models;

namespace HerrProgLibreriaDigital.Data
{
    public class AutorContext : DbContext
    {
        public AutorContext (DbContextOptions<AutorContext> options)
            : base(options)
        {
        }

        public DbSet<HerrProgLibreriaDigital.Models.Autor> Autor { get; set; } = default!;

        public DbSet<HerrProgLibreriaDigital.Models.Libro> Libro { get; set; } = default!;

        public DbSet<HerrProgLibreriaDigital.Models.Sucursal> Sucursal { get; set; } = default!;
    }
}
