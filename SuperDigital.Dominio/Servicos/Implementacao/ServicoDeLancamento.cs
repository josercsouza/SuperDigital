using SuperDigital.Dominio.Entidades;
using SuperDigital.Dominio.Interfaces;
using SuperDigital.Dominio.ObjetosDeValor;
using SuperDigital.Dominio.Repositorios;
using SuperDigital.Dominio.Servicos.Implementacao.Validadores;
using System;
using System.Collections.Generic;

namespace SuperDigital.Dominio.Servicos.Implementacao
{
    public class ServicoDeLancamento : IServicoDeLancamento
    {
        private readonly IRepositorioDeLancamento _repositorioDeLancamento;
        private readonly IRepositorioDeContaCorrente _repositorioDeContaCorrente;

        public ServicoDeLancamento(IRepositorioDeLancamento repositorioDeLancamento,
            IRepositorioDeContaCorrente repositorioDeContaCorrente)
        {
            _repositorioDeLancamento = repositorioDeLancamento;
            _repositorioDeContaCorrente = repositorioDeContaCorrente;
        }

        public bool Adicionar(LancamentoOV lancamentoOV)
        {
            try
            {
                if (!ValidarLancamento.Validar(lancamentoOV, _repositorioDeContaCorrente))
                    return false;

                var lancamento = new Lancamento
                {
                    ContaOrigem = lancamentoOV.ContaOrigem,
                    ContaDestino = lancamentoOV.ContaDestino,
                    Valor = lancamentoOV.Valor
                };

                // Alterar o saldo da Origem
                var contaOrigem = _repositorioDeContaCorrente.Obter(lancamento.ContaOrigem);
                contaOrigem.SaldoDaConta -= lancamento.Valor;
                _repositorioDeContaCorrente.Alterar(contaOrigem);

                // Alterar o saldo do destino
                var contaDestino = _repositorioDeContaCorrente.Obter(lancamento.ContaDestino);
                contaDestino.SaldoDaConta += lancamento.Valor;
                _repositorioDeContaCorrente.Alterar(contaDestino);

                // Adicionar Lancamento
                _repositorioDeLancamento.Adicionar(lancamento);

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Lancamento> Obter(string contaOrigem, string contaDestino, DateTime data)
        {
            return _repositorioDeLancamento.Obter(contaDestino, contaDestino, data);
        }

        public Lancamento Obter(long id)
        {
            return _repositorioDeLancamento.Obter(id);
        }
    }
}