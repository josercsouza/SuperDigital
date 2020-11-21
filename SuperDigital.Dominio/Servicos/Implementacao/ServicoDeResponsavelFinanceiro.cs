using SuperDigital.Dominio.Entidades;
using SuperDigital.Dominio.Interfaces;
using SuperDigital.Dominio.ObjetosDeValor;
using SuperDigital.Dominio.Repositorios;
using System;
using System.Threading.Tasks;

namespace SuperDigital.Dominio.Servicos.Implementacao
{
    public class ServicoDeResponsavelFinanceiro : IServicoDeResponsavelFinanceiro
    {
        private readonly IRepositorioDeResponsavelFinanceiro _repositorioDeResponsavelFinanceiro;

        public ServicoDeResponsavelFinanceiro(IRepositorioDeResponsavelFinanceiro repositorioDeResponsavelFinanceiro)
        {
            _repositorioDeResponsavelFinanceiro = repositorioDeResponsavelFinanceiro;
        }

        public async Task<bool> Adicionar(ResponsavelFinanceiroOV responsavelFinanceiroOV)
        {
            try
            {
                var responsavelFinanceiro = new ResponsavelFinanceiro
                {
                };

                // Adicionar Lancamento
                _repositorioDeResponsavelFinanceiro.Adicionar(responsavelFinanceiro);

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ResponsavelFinanceiro> Obter(string documento)
        {
            return await _repositorioDeResponsavelFinanceiro.Obter(documento);
        }
    }
}