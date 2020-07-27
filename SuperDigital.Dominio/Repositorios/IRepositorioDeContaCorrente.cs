using SuperDigital.Dominio.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SuperDigital.Dominio.Repositorios

{
    public interface IRepositorioDeContaCorrente
    {
        void Adicionar(ContaCorrente contaCorrente);

        void Alterar(ContaCorrente contaCorrente);

        void Excluir(ContaCorrente contaCorrente);

        Task<List<ContaCorrente>> ObterPorNome(string nome);

        Task<ContaCorrente> Obter(string numeroDaConta);
    }
}