using SuperDigital.Dominio.Entidades;
using SuperDigital.Dominio.Interfaces;
using SuperDigital.Dominio.Repositorios;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SuperDigital.Dominio.Servicos.Implementacao
{
    public class ServicoDeContaCorrente : IServicoDeContaCorrente
    {
        private readonly IRepositorioDeContaCorrente _repositorioDeContaCorrente;

        public ServicoDeContaCorrente(IRepositorioDeContaCorrente repositorioDeContaCorrente) =>
            _repositorioDeContaCorrente = repositorioDeContaCorrente;

        public async void Adicionar(ContaCorrente contaCorrente)
        {
            _repositorioDeContaCorrente.Adicionar(contaCorrente);
        }

        public async void Alterar(ContaCorrente contaCorrente)
        {
            _repositorioDeContaCorrente.Alterar(contaCorrente);
        }

        public async void Excluir(string numeroDaConta)
        {
            var contaCorrente = await _repositorioDeContaCorrente.Obter(numeroDaConta);
            _repositorioDeContaCorrente.Excluir(contaCorrente);
        }

        public async Task<List<ContaCorrente>> ObterPorNome(string nome)
        {
            return await _repositorioDeContaCorrente.ObterPorNome(nome);
        }

        public async Task<ContaCorrente> Obter(string numeroDaConta)
        {
            return await _repositorioDeContaCorrente.Obter(numeroDaConta);
        }
    }
}