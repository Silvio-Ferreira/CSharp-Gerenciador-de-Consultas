using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Consultas.Models;
using Microsoft.EntityFrameworkCore;

namespace Consultas.Context
{
    public class ConsultaContext : DbContext
    {
        public ConsultaContext(DbContextOptions<ConsultaContext> options) : base(options)
        {

        }

        public DbSet<Consulta> Consultas {get; set;}
    }
}