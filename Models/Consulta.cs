using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Consultas.Models
{
    public class Consulta
    {
        public int Id {get; set;}
        public string Nome {get; set;}
        public string Telefone {get; set;}
        public string Profissional {get; set;}
        public string Data {get; set;}
        public string Sintomas {get; set;}
    }
}