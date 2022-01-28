using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConexaoBD.DAL.Model
{
    public abstract class Entidade
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        
        [MinLength(3, ErrorMessage = "Este campo não pode possuir menos de 3 caracteres")]
        [MaxLength(255, ErrorMessage = "Este campo não pode possuir mais de 255 caracteres")]
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


        public Entidade()
        {
            //Se estas instruções estiverem ativas então funcionam tanto para o banco de dados como para o repositório
            Id = Guid.NewGuid();
            Ativo = true;
            DataCriacao = DateTime.Now;
            DataAlteracao = DateTime.Now;
        }
    }
}
