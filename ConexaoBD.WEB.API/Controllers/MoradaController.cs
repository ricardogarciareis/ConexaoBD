using ConexaoBD.DAL.Model;
using ConexaoBD.WEB.API.Conversores;
using ConexaoBD.WEB.API.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConexaoBD.WEB.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoradaController : ControllerBase
    {
        readonly ConexaoBDContexto ctx;
        public MoradaController()
        {
            ctx = new ConexaoBDContexto();
        }

        [HttpGet]
        public DataTableResponse GetMoradaPorId()
        {
            var morada = ctx.Moradas.Where(x => x.Id == 1);
            var moradaDto = new List<MoradaDto>();
            foreach (var item in morada)
            {
                var dtoTemp = MoradaAdapter.ConverterMoradaEmMoradaDto(item);
                moradaDto.Add(dtoTemp);
            }

            return new DataTableResponse
            {
                RecordsTotal = moradaDto.Count,
                RecordsFiltered = 10,
                Data = moradaDto.ToArray()
            };
        }
    }
}
