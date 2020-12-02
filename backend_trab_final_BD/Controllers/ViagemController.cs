using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend_trab_final_BD.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Oracle.ManagedDataAccess.Client;

namespace backend_trab_final_BD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ViagemController : ControllerBase
    {
        [HttpGet]
        public List<Viagem> GetViagens()
        {
            ViagemManager viagem = new ViagemManager();
            return viagem.GetViagens();
        }

        [HttpPost("insert")]
        public void PostViagem(int id, int numeroPassagens, double preco, string data, int origemId, int destinoId, int tripulacaoId, int aviaoId, decimal hrVoo)
        {
            ViagemManager viagem = new ViagemManager();
            viagem.InsereViagem(id, numeroPassagens, preco, data, origemId, destinoId, tripulacaoId, aviaoId, hrVoo);
        }

        [HttpPut("update")]
        public void UpdateViagem(int id, int numeroPassagens, double preco, string data, int origemId, int destinoId, int tripulacaoId, int aviaoId, decimal hrVoo)
        {
            ViagemManager viagem = new ViagemManager();
            viagem.UpdateViagem(id, numeroPassagens, preco, data, origemId, destinoId, tripulacaoId, aviaoId, hrVoo);
        }

        [HttpDelete("delete")]
        public void DeleteViagem(int id, int numeroPassagens, double preco, string data, int origemId, int destinoId, int tripulacaoId, int aviaoId)
        {
            ViagemManager viagem = new ViagemManager();
            viagem.DeleteViagem(id);
        }
    }
}
