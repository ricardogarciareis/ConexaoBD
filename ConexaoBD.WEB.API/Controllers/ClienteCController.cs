using ConexaoBD.DAL.Model;
using ConexaoBD.WEB.API.Conversores;
using ConexaoBD.WEB.API.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConexaoBD.WEB.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteCController : ControllerBase
    {
        readonly ConexaoBDContexto ctx;
        public ClienteCController()
        {
            ctx = new ConexaoBDContexto();
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
