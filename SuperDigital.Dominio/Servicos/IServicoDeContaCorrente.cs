using SuperDigital.Dominio.Entidades;
using System.Collections.Generic;

namespace SuperDigital.Dominio.Interfaces
{
    public interface IServicoDeContaCorrente
    {
        void Adicionar(ContaCorrente contaCorrente);

        void Alterar(ContaCorrente contaCorrente);

        void Excluir(string numeroDaConta);

        List<ContaCorrente> ObterPorNome(string nome);

        ContaCorrente Obter(string numeroDaConta);
    }
}