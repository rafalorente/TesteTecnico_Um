using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TesteTecnico_Um.Data.Dtos.Endereco
{
    public class ReadEnderecoDto
    {

        [Key]
        [Required]
        public int IdEndereco { get; set; }

        [Required(ErrorMessage = "O campo Logradouro é obrigatório")]
        public int IdLogradouro { get; set; }

        [Required(ErrorMessage = "O campo Motorista é obrigatório")]
        public int IdMotorista { get; set; }

        [Required(ErrorMessage = "O campo Cep é obrigatório")]
        public string Cep { get; set; }

        [Required(ErrorMessage = "O campo Nome da Rua é obrigatório")]
        public string NomeRua { get; set; }

        [Required(ErrorMessage = "O campo Numero é obrigatório")]
        public int Numero { get; set; }

        [Required(ErrorMessage = "O campo Complemento é obrigatório")]
        public string Complemento { get; set; }

        [Required(ErrorMessage = "O campo Bairro é obrigatório")]
        public int IdBairro { get; set; }

        [Required(ErrorMessage = "O campo Cidade é obrigatório")]
        public int IdCidade { get; set; }

        [Required(ErrorMessage = "O campo Estado é obrigatório")]
        public int IdEstado { get; set; }

    }
}
