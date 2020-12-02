using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend_trab_final_BD.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backend_trab_final_BD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnaliseController : ControllerBase
    {
        [HttpGet("listaPassageiros")]
        public List<AnalisePassageiro> ListaPassageiros()
        {
            AnaliseManager analise = new AnaliseManager();
            return analise.ListaPassageiros();
        }

        [HttpGet("FuncionarioTripulacao")]
        public List<AnaliseFuncionario> ListaFuncTrip()
        {
            AnaliseManager analise = new AnaliseManager();
            return analise.FuncionarioTrip();
        }

        [HttpGet("QuantViagem")]
        public List<AnalisePassageiro> QuantViagem()
        {
            AnaliseManager analise = new AnaliseManager();
            return analise.QuantViagens();
        }

        [HttpGet("MultViagem")]
        public List<AnalisePassageiro> MultViagem()
        {
            AnaliseManager analise = new AnaliseManager();
            return analise.MultViagens();
        }

        [HttpGet("IdadePassageiros")]
        public List<AnalisePassageiro> IdadePassageiros()
        {
            AnaliseManager analise = new AnaliseManager();
            return analise.IdadePassageiros();
        }
    }
}
