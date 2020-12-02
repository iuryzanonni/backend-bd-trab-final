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
    public class PassageiroController : ControllerBase
    {
        [HttpGet]
        public List<Passageiro> GetList()
        {
            PassageiroManager passageiro = new PassageiroManager();
            return passageiro.getListPassageiro();
        }

        [HttpPost("insert")]
        public void PostPassageiro(string cpf, string nome, string dataNascimento)
        {
            PassageiroManager passageiro = new PassageiroManager();
            passageiro.InsertPassageiro(cpf, nome, dataNascimento);
        }

        [HttpPut("update")]
        public void UpdatePassageiro(string cpf, string nome, string dataNascimento)
        {
            PassageiroManager passageiro = new PassageiroManager();
            passageiro.UpdatePassageiro(cpf, nome, dataNascimento);
        }

        [HttpDelete("delete")]
        public void DeletePassageiro(string cpf, string nome, string dataNascimento)
        {
            PassageiroManager passageiro = new PassageiroManager();
            passageiro.DeletePassageiro(cpf, nome, dataNascimento);
        }
    }
}
