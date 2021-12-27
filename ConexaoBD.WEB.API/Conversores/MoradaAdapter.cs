using ConexaoBD.DAL.Model;
using ConexaoBD.WEB.API.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConexaoBD.WEB.API.Conversores
{
    public static class MoradaAdapter
    {
        public static MoradaDto ConverterMoradaEmMoradaDto(Morada morada)
        {
            var dto = new MoradaDto
            {
                IdMorada = morada.Id,
                TipoMorada = morada.TipoMorada,
                TipoMoradaStr = morada.TipoMorada.ToString(),
                Distrito = morada.Distrito,
                Endereco = morada.Endereco,
                CodigoPostal = morada.CodigoPostal.Substring(0, 4) + "-" + morada.CodigoPostal.Substring(4, 3),
                Localidade = morada.Localidade
            };
            return dto;
        }
    }
}
