using SuperDigital.Dominio.Entidades;
using SuperDigital.Dominio.ObjetosDeValor;
using System.Threading.Tasks;

namespace SuperDigital.Dominio.Interfaces
{
    public interface IServicoDeResponsavelFinanceiro
    {
        Task<bool> Adicionar(ResponsavelFinanceiroOV responsavelFinanceiroOV);

        Task<ResponsavelFinanceiro> Obter(string documento);
    }
}