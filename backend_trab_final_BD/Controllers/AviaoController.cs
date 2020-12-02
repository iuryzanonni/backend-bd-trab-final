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
    public class AviaoController : ControllerBase
    {
        [HttpGet]
        public List<Aviao> getAviao()
        {
            AviaoManager aviao = new AviaoManager();
            return aviao.getListAviao();
        }

        [HttpPost("insert")]
        public void insertAviao(int id, string modelo, string dataFabricacao, string dataUltimaManutencao, int capacidade)
        {
            AviaoManager aviao = new AviaoManager();
            aviao.InsertAviao(id, modelo, dataFabricacao, dataUltimaManutencao, capacidade);
        }

        [HttpPut("update")]
        public void UpdateAviao(int id, string modelo, string dataFabricacao, string dataUltimaManutencao, int capacidade)
        {
            AviaoManager aviao = new AviaoManager();
            aviao.UpdateAviao(id, modelo, dataFabricacao, dataUltimaManutencao, capacidade);
        }

        [HttpDelete("delete")]
        public void DeleteAviao(int id)
        {
            AviaoManager aviao = new AviaoManager();
            aviao.DeleteAviao(id);
        }
    }
}
