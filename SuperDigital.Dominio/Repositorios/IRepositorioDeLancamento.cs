using SuperDigital.Dominio.Entidades;
using System;
using System.Collections.Generic;

namespace SuperDigital.Dominio.Repositorios
{
    public interface IRepositorioDeLancamento
    {
        void Adicionar(Lancamento lancamento);

        List<Lancamento> Obter(string contaOrigem, string contaDestino, DateTime? data = null);

        Lancamento Obter(long id);
    }
}