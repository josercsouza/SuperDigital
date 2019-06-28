using Microsoft.AspNetCore.Mvc;
using SuperDigital.Dominio.Entidades;
using SuperDigital.Dominio.Interfaces;
using System.Collections.Generic;

namespace SuperDigital.Aplicacao.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContaCorrenteController : ControllerBase
    {
        private readonly IServicoDeContaCorrente _servicoDeContaCorrente;

        public ContaCorrenteController(IServicoDeContaCorrente servicoDeContaCorrente)
        {
            _servicoDeContaCorrente = servicoDeContaCorrente;
        }

        [HttpGet]
        public ActionResult<List<ContaCorrente>> GetPorNome(string nome)
        {
            return Ok(_servicoDeContaCorrente.ObterPorNome(nome));
        }

        [HttpGet("{numeroDaConta}")]
        public ActionResult<ContaCorrente> Get(string numeroDaConta)
        {
            return Ok(_servicoDeContaCorrente.Obter(numeroDaConta));
        }

        [HttpPost]
        public void Post([FromBody] ContaCorrente contaCorrente)
        {
            _servicoDeContaCorrente.Adicionar(contaCorrente);
        }

        [HttpPut]
        public void Put([FromBody] ContaCorrente contaCorrente)
        {
            _servicoDeContaCorrente.Alterar(contaCorrente);
        }

        [HttpDelete("{numeroDaConta}")]
        public void Delete(string numeroDaConta)
        {
            _servicoDeContaCorrente.Excluir(numeroDaConta);
        }
    }
}