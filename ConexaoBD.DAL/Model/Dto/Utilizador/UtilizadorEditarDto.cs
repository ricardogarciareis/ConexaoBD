using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ConexaoBD.DAL.Model
{
    public class UtilizadorEditarDto
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Este campo é de preenchimento obrigatório")]
        public string Nome { get; set; }

        public bool Ativo { get; set; }

        public int GrupoDeUtilizadoresId { get; set; }

        [ForeignKey("GrupoDeUtilizadoresId")]
        public virtual GrupoDeUtilizadores GrupoDeUtilizadores { get; set; }
    }
}
