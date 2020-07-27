using SuperDigital.Dominio.Entidades;
using SuperDigital.Dominio.Interfaces;
using SuperDigital.Dominio.Repositorios;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SuperDigital.Dominio.Servicos.Implementacao
{
    public class ServicoDeAutorizacao : IServicoDeAutorizacao
    {
        private readonly IRepositorioDeAutorizacao _repositorioDeAutorizacao;

        public ServicoDeAutorizacao(IRepositorioDeAutorizacao repositorioDeLancamento) =>
            _repositorioDeAutorizacao = repositorioDeLancamento;

        public void Adicionar(Autorizacao autorizacao)
        {
            _repositorioDeAutorizacao.Adicionar(autorizacao);
        }

        public async Task<Autorizacao> Obter(Guid codigo)
        {
            return await _repositorioDeAutorizacao.Obter(codigo);
        }

        public async Task<List<Autorizacao>> ObterClientesIrregulares()
        {
            return await _repositorioDeAutorizacao.ObterClientesIrregulares();
        }
    }
}