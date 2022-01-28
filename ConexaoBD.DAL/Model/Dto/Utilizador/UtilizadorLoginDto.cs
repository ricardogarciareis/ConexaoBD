using ConexaoBD.DAL.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ConexaoBD.DAL.Model
{
    public class UtilizadorLoginDto
    {
        public string EmailLogin { get; set; }

        [ValidacaoDeLogin]
        public string PasswordLogin { get; set; }
    }
}
