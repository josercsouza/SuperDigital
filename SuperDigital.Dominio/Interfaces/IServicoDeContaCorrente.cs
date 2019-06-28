using SuperDigital.Dominio.Entidades;
using System.Collections.Generic;

namespace SuperDigital.Dominio.Interfaces
{
    public interface IServicoDeContaCorrente
    {
        void Adicionar(ContaCorrente contaCorrente);

        void Alterar(ContaCorrente contaCorrente);

        void Excluir(ContaCorrente contaCorrente);

        List<ContaCorrente> Obter(string nome, decimal saldo);

        ContaCorrente Obter(string numeroDaConta);
    }
}