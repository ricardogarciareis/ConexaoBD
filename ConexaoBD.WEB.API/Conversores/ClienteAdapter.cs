using ConexaoBD.DAL.Model;
using ConexaoBD.WEB.API.Dto;
using System;

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
                TipoDeMorada = cliente.MoradaCliente.TipoDeMorada,
                Distrito = cliente.MoradaCliente.Distrito,
                Endereco = cliente.MoradaCliente.Endereco,
                CodigoPostal = cliente.MoradaCliente.CodigoPostal,
                ZonaPostal = cliente.MoradaCliente.ZonaPostal,
                Localidade = cliente.MoradaCliente.Localidade
            };
            return dto;
        }
    }
}
