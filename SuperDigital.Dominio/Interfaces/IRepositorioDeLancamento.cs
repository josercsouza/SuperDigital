using SuperDigital.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperDigital.Dominio.Interfaces
{
    public interface IRepositorioDeLancamento
    {
        void Adicionar(Lancamento lancamento);

        List<Lancamento> Obter(string contaOrigem, string contaDestino, DateTimeOffset data);

        Lancamento Obter(long id);

    }
}
