using SuperDigital.Dominio.Entidades;
using SuperDigital.Dominio.Interfaces;
using SuperDigital.Dominio.ObjetosDeValor;
using SuperDigital.Dominio.Repositorios;
using SuperDigital.Dominio.Servicos.Implementacao.Validadores;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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

        public async Task<bool> Adicionar(LancamentoOV lancamentoOV)
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

                // inverte a operacao caso o valor seja negativo
                if (lancamentoOV.Valor < 0)
                {
                    lancamento.ContaOrigem = lancamentoOV.ContaDestino;
                    lancamento.ContaDestino = lancamentoOV.ContaOrigem;
                    lancamento.Valor *= (-1);
                }

                // Alterar o saldo da Origem
                var contaOrigem = await _repositorioDeContaCorrente.Obter(lancamento.ContaOrigem);
                contaOrigem.SaldoDaConta -= lancamento.Valor;
                _repositorioDeContaCorrente.Alterar(contaOrigem);

                // Alterar o saldo do destino
                var contaDestino = await _repositorioDeContaCorrente.Obter(lancamento.ContaDestino);
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

        public async Task<List<Lancamento>> Obter(string contaOrigem, string contaDestino, DateTime data)
        {
            return await _repositorioDeLancamento.Obter(contaDestino, contaDestino, data);
        }

        public async Task<Lancamento> Obter(long id)
        {
            return await _repositorioDeLancamento.Obter(id);
        }
    }
}