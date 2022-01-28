using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConexaoBD.DAL.Model
{
    public abstract class EntidadeSimples
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Este campo é de preenchimento obrigatório")]
        public string Nome { get; set; }

        public bool Ativo { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Data Criação")]
        public DateTime DataCriacao { get; set; }

        [Display(Name = "Criado Por")]
        public string CriadoPor { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Data Últ. Alteração")]
        public DateTime DataAlteracao { get; set; }

        [Display(Name = "Alterado Por")]
        public string AlteradoPor { get; set; }


        public EntidadeSimples()
        {
            //Se estas instruções estiverem ativas então funcionam tanto para o banco de dados como para o repositório
            Ativo = true;
            DataCriacao = DateTime.Now;
            DataAlteracao = DateTime.Now;
        }
    }
}
