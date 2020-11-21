using Microsoft.AspNetCore.Mvc;
using SuperDigital.Dominio.Entidades;
using SuperDigital.Dominio.Interfaces;
using SuperDigital.Dominio.ObjetosDeValor;
using System.Threading.Tasks;

namespace SuperDigital.Aplicacao.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResponsavelFinanceiroController : ControllerBase
    {
        private readonly IServicoDeResponsavelFinanceiro _servicoDeResponsavelFinanceiro;

        public ResponsavelFinanceiroController(IServicoDeResponsavelFinanceiro servicoDeResponsavelFinanceiro) =>
            _servicoDeResponsavelFinanceiro = servicoDeResponsavelFinanceiro;

        [HttpGet("{documento}")]
        public async Task<ResponsavelFinanceiro> Get(string documento)
        {
            return await _servicoDeResponsavelFinanceiro.Obter(documento);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ResponsavelFinanceiroOV responsavelFinanceiroOV)
        {
            if (await _servicoDeResponsavelFinanceiro.Adicionar(responsavelFinanceiroOV))
                return Ok();
            else
                return BadRequest();
        }
    }
}