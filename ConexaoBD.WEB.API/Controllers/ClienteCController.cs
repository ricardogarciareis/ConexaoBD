using ConexaoBD.DAL.Model;
using ConexaoBD.WEB.API.Conversores;
using ConexaoBD.WEB.API.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace ConexaoBD.WEB.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteCController : ControllerBase
    {
        //CRUD de acesso à Base de Dados:
        private readonly ConexaoBDContexto ctx;

        public ClienteCController(ConexaoBDContexto _ctx)
        {
            ctx = _ctx;
        }

        [HttpGet]
        public DataTableResponse GetClientes()
        {
            //var clientes = ctx.Clientes.Where(c => c.Ativo == true).ToList();
            var clientes = ctx.Clientes.Include("MoradaCliente");
            var clientesDto = new List<ClienteDto>();

            foreach (var item in clientes)
            {
                var dtoTemp = ClienteAdapter.ConverterClienteEmClienteDto(item);
                clientesDto.Add(dtoTemp);
            }

            return new DataTableResponse
            {
                RecordsTotal = clientesDto.Count,
                RecordsFiltered = 10,
                Data = clientesDto.ToArray()
            };
        }
    }
}
