using SuperDigital.Dominio.Entidades;
using System;
using System.Collections.Generic;

namespace SuperDigital.Dominio.Interfaces
{
    public interface IServicoDeLancamento
    {
        void Adicionar(Lancamento lancamento);

        List<Lancamento> Obter(string contaOrigem, string contaDestino, DateTimeOffset data);

        Lancamento Obter(long id);
    }
}