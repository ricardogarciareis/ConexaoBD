using ConexaoBD.DAL.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ConexaoBD.WEB.API.Dto
{
    public class MoradaDto
    {
        public int IdMorada { get; set; }

        public TipoMorada TipoMorada { get; set; }

        public string TipoMoradaStr { get; set; }

        public string Distrito { get; set; }

        public string Endereco { get; set; }

        public string CodigoPostal { get; set; }

        public string Localidade { get; set; }
    }
}
