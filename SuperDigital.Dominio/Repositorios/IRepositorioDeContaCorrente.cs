using SuperDigital.Dominio.Entidades;
using System.Collections.Generic;

namespace SuperDigital.Dominio.Repositorios

{
    public interface IRepositorioDeContaCorrente
    {
        void Adicionar(ContaCorrente contaCorrente);

        void Alterar(ContaCorrente contaCorrente);

        void Excluir(ContaCorrente contaCorrente);

        List<ContaCorrente> ObterPorNome(string nome);

        ContaCorrente Obter(string numeroDaConta);
    }
}