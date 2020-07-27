using SuperDigital.Dominio.Entidades;
using SuperDigital.Dominio.ObjetosDeValor;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SuperDigital.Dominio.Interfaces
{
    public interface IServicoDeLancamento
    {
        Task<bool> Adicionar(LancamentoOV lancamentoOV);

        Task<List<Lancamento>> Obter(string contaOrigem, string contaDestino, DateTime data);

        Task<Lancamento> Obter(long id);
    }
}