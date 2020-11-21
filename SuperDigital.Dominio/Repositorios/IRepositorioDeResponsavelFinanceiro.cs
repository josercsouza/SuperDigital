using SuperDigital.Dominio.Entidades;
using System.Threading.Tasks;

namespace SuperDigital.Dominio.Repositorios
{
    public interface IRepositorioDeResponsavelFinanceiro
    {
        void Adicionar(ResponsavelFinanceiro responsavelFinanceiro);

        Task<ResponsavelFinanceiro> Obter(string documento);
    }
}