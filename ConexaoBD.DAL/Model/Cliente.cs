using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ConexaoBD.DAL.Model
{
    public class Cliente : Entidade
    {
        [Required(ErrorMessage = "Este campo é de preenchimento obrigatório")]
        [MinLength(9, ErrorMessage = "Este campo não pode possuir menos de 9 caracteres"), MaxLength(9, ErrorMessage = "Este campo não pode possuir mais de 9 caracteres")]
        [Display(Name = "N.I.F.")]
        public string NIF { get; set; }

        [Required(ErrorMessage = "Este campo é de preenchimento obrigatório")]
        [DataType(DataType.DateTime)]
        [Display(Name = "Data de Nascimento")]
        public DateTime DataNascimento { get; set; }

        [NotMapped]
        [Display(Name = "Idade")]
        public int Idade => ((DateTime.Now.Year - DataNascimento.Year) * 372 + (DateTime.Now.Month - DataNascimento.Month) * 31 + (DateTime.Now.Day - DataNascimento.Day)) / 372;

        public virtual Morada MoradaCliente { get; set; }

        [DataType(DataType.Upload)]
        [Display(Name ="Upload de Ficheiro")]
        public string Ficheiro { get; set; }


        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine("                ID: " + Id);
            sb.AppendLine("              Nome: " + Nome);
            sb.AppendLine("               NIF: " + NIF);
            sb.AppendLine("Data de Nascimento: " + DataNascimento);
            sb.AppendLine("             Idade: " + Idade);
            sb.AppendLine("             Ativo: " + Ativo);
            sb.AppendLine("   Data de Criação: " + DataCriacao);
            sb.AppendLine(" Data de Alteração: " + DataAlteracao);
            sb.AppendLine("    Tipo de Morada: " + MoradaCliente.TipoDeMorada);
            sb.AppendLine("          Distrito: " + MoradaCliente.Distrito);
            sb.AppendLine("          Endereço: " + MoradaCliente.Endereco);
            sb.AppendLine("     Código-Postal: " + MoradaCliente.CodigoPostal + "-" + MoradaCliente.ZonaPostal);
            sb.AppendLine("        Localidade: " + MoradaCliente.Localidade);
            return sb.ToString();
        }
    }
}
