using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace T2Su.Models
{
    public class Registro
    {
        public int Id { get; set; }
        //
        [Required(ErrorMessage = "Digite o Nome do Cliente")]
        [StringLength(20)]
        public string Cliente { get; set; }


        [Display(Name = "Contêiner")]
        [StringLength(11, ErrorMessage = "Digite somente 11 caracteres 4 letras e 7 numeros.")]

        [MinLengthAttribute(11, ErrorMessage = "Deve se inserido 11 caracteres 4 letras e 7 numeros. ")]
        [Required(ErrorMessage = "Código do Contêiner deve ser inserido desta forma (Test1234567)!.")]
        public string CodigodeContainer { get; set; }
        ///Escolhaid
        /*[Display(Name = "Tipo")]
        [Required(ErrorMessage = "Insira o tamanho Do container")]*/
        [Display(Name = "Tipo")]
        [Required(ErrorMessage = "Campo obrigadorio escolha uma opção")]
        public int EscolhaId { get; set; }
        public Escolha Escolha { get; set; }
        ///Cadastroid
        [Display(Name = "Status")]
        [Required(ErrorMessage = "Campo obrigadorio escolha uma opção")]
        public int CadastroId { get; set; }
        public Cadastro Cadastro { get; set; }
        //
        [Display(Name = "Categoria")]
        [Required(ErrorMessage = "Campo obrigadorio escolha uma opção")]
        public int CateId { get; set; }
        public Cate Cate { get; set; }
        //TipodeMovimentação
        [Display(Name = "Movimentação")]
        [Required(ErrorMessage = "Campo obrigadorio escolha uma opção")]
        public int TipomoviId { get; set; }
        public Tipomovi Tipomovi { get; set; }

        //Data e Hora e Inicio
        [Display(Name = "Data e hora de inicio")]
        [Required(ErrorMessage = "Campo Obrigadorio, Digite data e hora de inicio de froma correta")]
        public DateTime DataInicio { get; set; }

        //Fim
        [Display(Name = "Data e Hora de fim")]
        [Required(ErrorMessage = "Campo Obrigadorio, Digite data e hora de fim de forma correta")]
        public DateTime DataDeFim { get; set; }


    }
}
