using SuperDigital.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperDigital.Dominio.Interfaces
{
    public interface IRepositorioDeContaCorrente
    {
        void Adicionar(ContaCorrente contaCorrente);

        void Alterar(ContaCorrente contaCorrente);

        void Excluir(ContaCorrente contaCorrente);

        List<ContaCorrente> Obter(string nome, decimal saldo);

        ContaCorrente Obter(string numeroDaConta);

    }
}
