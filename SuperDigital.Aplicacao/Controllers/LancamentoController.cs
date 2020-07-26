using Microsoft.AspNetCore.Mvc;
using SuperDigital.Dominio.Entidades;
using SuperDigital.Dominio.Interfaces;
using SuperDigital.Dominio.ObjetosDeValor;
using System;
using System.Collections.Generic;

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
        public ActionResult<IEnumerable<Lancamento>> Get(string contaOrigem, string contaDestino, DateTime data)
        {
            return _servicoDeLancamento.Obter(contaOrigem, contaDestino, data);
        }

        [HttpGet("{id}")]
        public ActionResult<Lancamento> Get(long id)
        {
            return _servicoDeLancamento.Obter(id);
        }

        [HttpPost]
        public ActionResult Post([FromBody] LancamentoOV lancamentoOV)
        {
            if (_servicoDeLancamento.Adicionar(lancamentoOV))
                return Ok();
            else
                return BadRequest();
        }
    }
}