using ConexaoBD.DAL.Model;
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
    public class ClienteAController : ControllerBase
    {
        readonly ConexaoBDContexto ctx;
        public ClienteAController()
        {
            ctx = new ConexaoBDContexto();
        }

        [HttpGet]
        public int GetNumeroDeClientes()
        {
            var soma = ctx.Clientes.Where(c => c.Ativo == true).Count();
            return soma;
        }
    }
}
