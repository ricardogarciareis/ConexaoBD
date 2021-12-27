using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConexaoBD.DAL.Model
{
    public class Morada
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public TipoMorada TipoMorada { get; set; }

        [Required]
        [MaxLength(30)]
        public string Distrito { get; set; }

        [Required]
        [MaxLength(60)]
        public string Endereco { get; set; }

        [Required]
        [MinLength(7), MaxLength(7)]
        public string CodigoPostal { get; set; }

        [Required]
        [MaxLength(30)]
        public string Localidade { get; set; }
    }
}
