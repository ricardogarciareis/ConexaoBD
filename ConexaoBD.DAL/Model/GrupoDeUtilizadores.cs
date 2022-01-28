using System.ComponentModel.DataAnnotations;

namespace ConexaoBD.DAL.Model
{
    public class GrupoDeUtilizadores : EntidadeSimples
    {
        [Display(Name = "Tipo de Grupo de Utilizadores")]
        public string TipoDeGrupoDeUtilizadores { get; set; }

    }
}
