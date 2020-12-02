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
    public class LocalizacaoController : ControllerBase
    {
        [HttpGet]
        public List<Localizacao> getList()
        {
            LocalizacaoManager localizacao = new LocalizacaoManager();
            return localizacao.GetList();
        }

        [HttpPost("insert")]
        public void InsertLocalizacao(int id, string nome, string cidade, string estado)
        {
            LocalizacaoManager localizacao = new LocalizacaoManager();
            localizacao.InsertLocalizacao(id, nome, cidade, estado);
        }

        [HttpPut("update")]
        public void UpdateLocalizacao(int id, string nome, string cidade, string estado)
        {
            LocalizacaoManager localizacao = new LocalizacaoManager();
            localizacao.UpdateLocalizacao(id, nome, cidade, estado);
        }

        [HttpDelete("delete")]
        public void DeleteLocalizacao(int id, string nome, string cidade, string estado)
        {
            LocalizacaoManager localizacao = new LocalizacaoManager();
            localizacao.DeleteLocalizacao(id);
        }
    }
}
