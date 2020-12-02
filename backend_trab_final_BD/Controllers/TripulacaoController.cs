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
    public class TripulacaoController : ControllerBase
    {
        [HttpGet]
        public List<Tripulacao> GetFuncionarios()
        {
            TripulacaoManager tripulacao = new TripulacaoManager();
            return tripulacao.GetList();
        }

        [HttpPost("insert")]
        public void InsertTripulação(int id, string pilotoCPF, string copilotoCPF, string comissario1CPF, string comissario2CPF)
        {
            TripulacaoManager tripulacao = new TripulacaoManager();
            tripulacao.InsereTripulacao(id, pilotoCPF, copilotoCPF, comissario1CPF,comissario2CPF);
        }

        [HttpPut("update")]
        public void UpdateTripulação(int id, string pilotoCPF, string copilotoCPF, string comissario1CPF, string comissario2CPF)
        {
            TripulacaoManager tripulacao = new TripulacaoManager();
            tripulacao.UpdateTripulacao(id, pilotoCPF, copilotoCPF, comissario1CPF, comissario2CPF);
        }

        [HttpDelete("delete")]
        public void deleteTripulação(int id, string pilotoCPF, string copilotoCPF, string comissario1CPF, string comissario2CPF)
        {
            TripulacaoManager tripulacao = new TripulacaoManager();
            tripulacao.DeleteTripulacao(id);
        }

    }
}
