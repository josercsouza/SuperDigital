using SuperDigital.Dominio.Entidades;
using SuperDigital.Dominio.Interfaces;
using SuperDigital.Dominio.Repositorios;
using System.Collections.Generic;

namespace SuperDigital.Dominio.Servicos.Implementacao
{
    public class ServicoDeContaCorrente : IServicoDeContaCorrente
    {
        private readonly IRepositorioDeContaCorrente _repositorioDeContaCorrente;

        public ServicoDeContaCorrente(IRepositorioDeContaCorrente repositorioDeContaCorrente) =>
            _repositorioDeContaCorrente = repositorioDeContaCorrente;

        public void Adicionar(ContaCorrente contaCorrente)
        {
            _repositorioDeContaCorrente.Adicionar(contaCorrente);
        }

        public void Alterar(ContaCorrente contaCorrente)
        {
            _repositorioDeContaCorrente.Alterar(contaCorrente);
        }

        public void Excluir(string numeroDaConta)
        {
            var contaCorrente = _repositorioDeContaCorrente.Obter(numeroDaConta);
            _repositorioDeContaCorrente.Excluir(contaCorrente);
        }

        public List<ContaCorrente> ObterPorNome(string nome)
        {
            return _repositorioDeContaCorrente.ObterPorNome(nome);
        }

        public ContaCorrente Obter(string numeroDaConta)
        {
            return _repositorioDeContaCorrente.Obter(numeroDaConta);
        }
    }
}