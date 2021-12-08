using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TesteTecnico_Um.Data.Dtos
{
    public class ReadMotoristaDto
    {
        [Key]
        [Required]
        public int IdMotorista { get; set; }

        [Required(ErrorMessage = "O campo nome é obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo sobrenome é obrigatório")]
        public string UltimoNome { get; set; }
    }
}
