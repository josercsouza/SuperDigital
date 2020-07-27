using Microsoft.AspNetCore.Mvc;
using SuperDigital.Dominio.Entidades;
using SuperDigital.Dominio.Interfaces;
using SuperDigital.Dominio.ObjetosDeValor;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SuperDigital.Aplicacao.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LancamentoController : ControllerBase
    {
        private readonly IServicoDeLancamento _servicoDeLancamento;

        public LancamentoController(IServicoDeLancamento servicoDeLancamento) => 
            _servicoDeLancamento = servicoDeLancamento;

        [HttpGet]
        public async Task<IEnumerable<Lancamento>> Get(string contaOrigem, string contaDestino, DateTime data)
        {
            return await _servicoDeLancamento.Obter(contaOrigem, contaDestino, data);
        }

        [HttpGet("{id}")]
        public async Task<Lancamento> Get(long id)
        {
            return await _servicoDeLancamento.Obter(id);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] LancamentoOV lancamentoOV)
        {
            if (await _servicoDeLancamento.Adicionar(lancamentoOV))
                return Ok();
            else
                return BadRequest();
        }
    }
}