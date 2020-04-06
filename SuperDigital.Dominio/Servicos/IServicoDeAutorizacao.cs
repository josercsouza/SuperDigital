using SuperDigital.Dominio.Entidades;
using System;
using System.Collections.Generic;

namespace SuperDigital.Dominio.Interfaces
{
    public interface IServicoDeAutorizacao
    {
        void Adicionar(Autorizacao autorizacao);

        List<Autorizacao> ObterClientesIrregulares();

        Autorizacao Obter(Guid codigo);
    }
}