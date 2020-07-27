using SuperDigital.Dominio.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SuperDigital.Dominio.Interfaces
{
    public interface IServicoDeContaCorrente
    {
        void Adicionar(ContaCorrente contaCorrente);

        void Alterar(ContaCorrente contaCorrente);

        void Excluir(string numeroDaConta);

        Task<List<ContaCorrente>> ObterPorNome(string nome);

        Task<ContaCorrente> Obter(string numeroDaConta);
    }
}