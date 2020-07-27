using SuperDigital.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SuperDigital.Dominio.Repositorios
{
    public interface IRepositorioDeLancamento
    {
        void Adicionar(Lancamento lancamento);

        Task<List<Lancamento>> Obter(string contaOrigem, string contaDestino, DateTime? data = null);

        Task<Lancamento> Obter(long id);
    }
}