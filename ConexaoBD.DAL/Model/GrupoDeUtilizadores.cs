using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConexaoBD.DAL.Model
{
    public class GrupoDeUtilizadores : EntidadeSimples
    {
        [Display(Name = "Tipo de Grupo de Utilizadores")]
        public string TipoDeGrupoDeUtilizadores { get; set; }

    }
}
