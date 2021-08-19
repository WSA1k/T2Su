using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace T2Su.Models
{
    [Display(Name = "Categoria")]
    public class Cate
    {
        public int Id { get; set; }
        public string Categoria { get; set; }
        public List<Registro> Registros { get; set; }
    }
}
