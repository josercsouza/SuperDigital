using SuperDigital.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SuperDigital.Dominio.Repositorios
{
    public interface IRepositorioDeAutorizacao
    {
        void Adicionar(Autorizacao autorizacao);

        Task<List<Autorizacao>> ObterClientesIrregulares();

        Task<Autorizacao> Obter(Guid codigo);
    }
}