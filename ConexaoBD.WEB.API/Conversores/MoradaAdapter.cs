using ConexaoBD.DAL.Model;
using ConexaoBD.WEB.API.Dto;

namespace ConexaoBD.WEB.API.Conversores
{
    public static class MoradaAdapter
    {
        public static MoradaDto ConverterMoradaEmMoradaDto(Morada morada)
        {
            var dto = new MoradaDto
            {
                IdMorada = morada.Id,
                TipoDeMorada = morada.TipoDeMorada,
                Distrito = morada.Distrito,
                Endereco = morada.Endereco,
                CodigoPostal = morada.CodigoPostal,
                ZonaPostal = morada.ZonaPostal,
                Localidade = morada.Localidade
            };
            return dto;
        }
    }
}
