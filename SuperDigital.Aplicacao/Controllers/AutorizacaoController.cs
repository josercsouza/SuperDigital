using Microsoft.AspNetCore.Mvc;
using SuperDigital.Dominio.Entidades;
using SuperDigital.Dominio.Interfaces;
using System;

namespace SuperDigital.Aplicacao.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutorizacaoController : ControllerBase
    {
        private readonly IServicoDeAutorizacao _servicoDeAutorizacao;

        public AutorizacaoController(IServicoDeAutorizacao servicoDeAutorizacao)
        {
            _servicoDeAutorizacao = servicoDeAutorizacao;
        }

        [HttpGet("{codigo}")]
        public ActionResult<Autorizacao> Get(Guid codigo)
        {
            return _servicoDeAutorizacao.Obter(codigo);
        }

        [HttpGet("Revalidar")]
        public ActionResult<Autorizacao> Revalidar()
        {
            return Ok(_servicoDeAutorizacao.ObterClientesIrregulares());
        }

        [HttpPost]
        public ActionResult Post([FromBody] Autorizacao autorizacao)
        {
            _servicoDeAutorizacao.Adicionar(autorizacao);
            return Ok();
        }
    }
}