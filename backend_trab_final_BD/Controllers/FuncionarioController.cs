using backend_trab_final_BD.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace backend_trab_final_BD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionarioController : ControllerBase
    {
        [HttpGet]
        public List<Funcionario> GetFuncionarios()
        {
            FuncionarioManager manager = new FuncionarioManager();
            return manager.GetList();
        }

        [HttpPost("insert")]
        public void InsertFuncionario(string cpf, string nome, string cargo, string dataContratacao, decimal hrVoo)
        {
            FuncionarioManager manager = new FuncionarioManager();
            manager.InsertFuncionario(cpf, nome, cargo, dataContratacao, hrVoo);
        }

        [HttpDelete("delete")]
        public void DeleteFuncionario(string cpf)
        {
            FuncionarioManager manager = new FuncionarioManager();
            manager.DeleteFuncionario(cpf);
        }

        [HttpPut("update")]
        public void UpdateFuncionario(string cpf, string nome, string cargo, string dataContratacao, decimal hrVoo)
        {
            FuncionarioManager manager = new FuncionarioManager();
            manager.UpdateFuncionario(cpf,nome,cargo, dataContratacao, hrVoo);
        }
    }
}
