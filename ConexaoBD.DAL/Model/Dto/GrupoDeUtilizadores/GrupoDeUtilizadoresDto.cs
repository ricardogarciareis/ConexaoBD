using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConexaoBD.DAL.Model.Dto.GrupoDeUtilizadores
{
    public class GrupoDeUtilizadoresDto
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Este campo é de preenchimento obrigatório")]
        [MinLength(3, ErrorMessage = "Este campo não pode possuir menos de 3 caracteres")]
        [MaxLength(30, ErrorMessage = "Este campo não pode possuir mais de 30 caracteres")]
        public string Nome { get; set; }

        public bool Ativo { get; set; }

        [Display(Name = "Tipo de Grupo de Utilizadores")]
        public string TipoDeGrupoDeUtilizadores { get; set; }

    }
}
