using SuperDigital.Dominio.Entidades;
using SuperDigital.Dominio.ObjetosDeValor;
using System;
using System.Collections.Generic;

namespace SuperDigital.Dominio.Interfaces
{
    public interface IServicoDeLancamento
    {
        bool Adicionar(LancamentoOV lancamentoOV);

        List<Lancamento> Obter(string contaOrigem, string contaDestino, DateTime data);

        Lancamento Obter(long id);
    }
}