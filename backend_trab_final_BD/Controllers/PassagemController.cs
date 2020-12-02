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
    public class PassagemController : ControllerBase
    {
        [HttpGet]
        public List<Passagem> GetPassagem()
        {
            PassagemManager passagem = new PassagemManager();
            return passagem.GetPassagem();
        }

        [HttpPost("insert")]
        public void PostPassagem(string passageiroCPF, int viagemId, int poltrona)
        {
            PassagemManager passagem = new PassagemManager();
            passagem.InserePassagem(passageiroCPF, viagemId, poltrona);
        }

        [HttpPut("update")]
        public void PutPassagem(string passageiroCPF, int viagemId, int poltrona)
        {
            PassagemManager passagem = new PassagemManager();
            passagem.UpdatePassagem(passageiroCPF, viagemId, poltrona);
        }

        [HttpDelete("delete")]
        public void DeletePassagem(string passageiroCPF, int viagemId)
        {
            PassagemManager passagem = new PassagemManager();
            passagem.DeletePassagem(passageiroCPF, viagemId);
        }
    }
}
