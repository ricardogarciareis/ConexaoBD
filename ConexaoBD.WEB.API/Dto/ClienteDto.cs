using System;
using System.ComponentModel.DataAnnotations;

namespace ConexaoBD.WEB.API.Dto
{
    public class ClienteDto
    {
        public Guid Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Nome { get; set; }

        [Required]
        [MinLength(9), MaxLength(9)]
        public string NIF { get; set; }

        [Required]
        public bool Ativo { get; set; }

        //public DateTime? DataCriacao { get; set; }
        public string DataCriacao { get; set; }

        //public DateTime? DataAlteracao { get; set; }
        public string DataAlteracao { get; set; }

        //public MoradaDto MoradaCliente { get; set; }

        public int IdMorada { get; set; }

        public string TipoDeMorada { get; set; }

        public string Distrito { get; set; }

        public string Endereco { get; set; }

        public string CodigoPostal { get; set; }

        public string ZonaPostal { get; set; }

        public string Localidade { get; set; }


    }
}
