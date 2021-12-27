using ConexaoBD.DAL.Model;
using ConexaoBD.WEB.API.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConexaoBD.WEB.API.Conversores
{
    public static class ClienteAdapter
    {
        public static ClienteDto ConverterClienteEmClienteDto(Cliente cliente)
        {
            var dto = new ClienteDto
            {
                Id = cliente.Id,
                Nome = cliente.Nome,
                NIF = cliente.NIF,
                Ativo = cliente.Ativo,
                DataCriacao = ((DateTime)cliente.DataCriacao).ToString("MM/dd/yyyy HH:mm"),
                DataAlteracao = ((DateTime)cliente.DataAlteracao).ToString("MM/dd/yyy HH:mm"),
                IdMorada = cliente.MoradaCliente.Id,
                TipoMorada = cliente.MoradaCliente.TipoMorada,
                TipoMoradaStr = cliente.MoradaCliente.TipoMorada.ToString(),
                Distrito = cliente.MoradaCliente.Distrito,
                Endereco = cliente.MoradaCliente.Endereco,
                CodigoPostal = cliente.MoradaCliente.CodigoPostal.Substring(0, 4) + "-" + cliente.MoradaCliente.CodigoPostal.Substring(4, 3),
                Localidade = cliente.MoradaCliente.Localidade
            };
            return dto;
        }
    }
}
