using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace T2Su.Models
{
    public class Cadastro
    {
        public int id { get; set; }

        public string Status { get; set; }
        public List<Registro> Registros { get; set; }
    }
}
