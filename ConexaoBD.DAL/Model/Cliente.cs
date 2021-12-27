using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ConexaoBD.DAL.Model
{
    public class Cliente : Entidade
    {
        [Required]
        [MinLength(9), MaxLength(9)]
        public string NIF { get; set; }

        public virtual Morada MoradaCliente { get; set; }

        
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine("             ID: " + Id);
            sb.AppendLine("           Nome: " + Nome);
            sb.AppendLine("            NIF: " + NIF);
            sb.AppendLine("          Ativo: " + Ativo);
            sb.AppendLine("Data de Criação: " + DataCriacao);
            sb.AppendLine(" Tipo de Morada: " + MoradaCliente.TipoMorada);
            sb.AppendLine("       Distrito: " + MoradaCliente.Distrito);
            sb.AppendLine("       Endereço: " + MoradaCliente.Endereco);
            sb.AppendLine("  Código-Postal: " + MoradaCliente.CodigoPostal.Substring(0, 4) + "-" + MoradaCliente.CodigoPostal.Substring(4, 3));
            sb.AppendLine("     Localidade: " + MoradaCliente.Localidade);
            return sb.ToString();
        }
    }
}
