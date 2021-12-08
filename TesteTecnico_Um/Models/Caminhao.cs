using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TesteTecnico_Um.Models
{
    public class Caminhao
    {
        [Key]
        [Required]
        public int IdCaminhao { get; set; }

        [Required(ErrorMessage = "O campo Marca é obrigatório")]
        public string Marca { get; set; }

        [Required(ErrorMessage = "O campo Modelo é obrigatório")]
        public string Modelo { get; set; }

        [Required(ErrorMessage = "O campo Placa é obrigatório")]
        public string Placa { get; set; }

        [Required(ErrorMessage = "O campo Eixo é obrigatório")]
        public int Eixo { get; set; }

    }
}
