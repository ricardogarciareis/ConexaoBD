using ConexaoBD.DAL.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

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

        public TipoMorada TipoMorada { get; set; }

        public string TipoMoradaStr { get; set; }

        public string Distrito { get; set; }

        public string Endereco { get; set; }

        public string CodigoPostal { get; set; }

        public string Localidade { get; set; }


    }
}
