using SuperDigital.Dominio.Entidades;
using SuperDigital.Dominio.Interfaces;
using SuperDigital.Dominio.Repositorios;
using System;
using System.Collections.Generic;

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

        public Autorizacao Obter(Guid codigo)
        {
            return _repositorioDeAutorizacao.Obter(codigo);
        }

        public List<Autorizacao> ObterClientesIrregulares()
        {
            return _repositorioDeAutorizacao.ObterClientesIrregulares();
        }
    }
}