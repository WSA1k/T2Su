using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace T2Su.Models
{
    public class Escolha
    {

        public int Id { get; set; }
        public int Tipo { get; set; }
        public List<Registro> Registros { get; set; }
    }
}
