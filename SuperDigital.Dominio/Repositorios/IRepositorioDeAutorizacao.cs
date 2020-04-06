using SuperDigital.Dominio.Entidades;
using System;
using System.Collections.Generic;

namespace SuperDigital.Dominio.Repositorios
{
    public interface IRepositorioDeAutorizacao
    {
        void Adicionar(Autorizacao autorizacao);

        List<Autorizacao> ObterClientesIrregulares();

        Autorizacao Obter(Guid codigo);
    }
}