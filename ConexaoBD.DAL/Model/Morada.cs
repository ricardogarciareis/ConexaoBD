using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConexaoBD.DAL.Model
{
    public class Morada
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [NotMapped]
        [Display(Name = "Tipo de Morada")]
        public TipoMorada TipoMorada { get; set; }

        [Required(ErrorMessage = "Este campo é de preenchimento obrigatório")]
        [Display(Name = "Tipo de Morada")]
        public string TipoDeMorada { get; set; }

        [Required(ErrorMessage = "Este campo é de preenchimento obrigatório")]
        [MaxLength(30, ErrorMessage = "Este campo não pode possuir mais de 30 caracteres")]
        [Display(Name = "Distrito")]
        public string Distrito { get; set; }

        [Required(ErrorMessage = "Este campo é de preenchimento obrigatório")]
        [MaxLength(60, ErrorMessage = "Este campo não pode possuir mais de 60 caracteres")]
        [Display(Name = "Endereço")]
        public string Endereco { get; set; }

        [Required(ErrorMessage = "Este campo é de preenchimento obrigatório")]
        [MinLength(4, ErrorMessage = "Este campo não pode possuir menos de 4 caracteres"), MaxLength(4, ErrorMessage = "Este campo não pode possuir mais de 4 caracteres")]
        [Display(Name = "Código Postal")]
        public string CodigoPostal { get; set; }

        [Required(ErrorMessage = "Este campo é de preenchimento obrigatório")]
        [MinLength(3, ErrorMessage = "Este campo não pode possuir menos de 3 caracteres"), MaxLength(3, ErrorMessage = "Este campo não pode possuir mais de 3 caracteres")]
        [Display(Name = "Zona Postal")]
        public string ZonaPostal { get; set; }

        [Required(ErrorMessage = "Este campo é de preenchimento obrigatório")]
        [MaxLength(30, ErrorMessage = "Este campo não pode possuir mais de 30 caracteres")]
        [Display(Name = "Localidade")]
        public string Localidade { get; set; }
    }

}
