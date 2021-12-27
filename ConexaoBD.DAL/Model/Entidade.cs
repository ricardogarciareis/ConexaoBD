using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConexaoBD.DAL.Model
{
    public abstract class Entidade
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Nome { get; set; }

        public bool Ativo { get; set; }

        public DateTime? DataCriacao { get; set; }
        public DateTime? DataAlteracao { get; set; }

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
