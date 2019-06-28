using Microsoft.EntityFrameworkCore;
using SuperDigital.Dominio.Entidades;
using SuperDigital.Dominio.Interfaces;
using SuperDIgital.Infraestrutura.Contexto;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SuperDIgital.Infraestrutura.Repositorio
{
    public class RepositorioDeLancamento : IRepositorioDeLancamento, IDisposable
    {
        private readonly DbContextOptionsBuilder<ContextoBase> _opcoesBuilder;

        public RepositorioDeLancamento()
        {
            _opcoesBuilder = new DbContextOptionsBuilder<ContextoBase>();
        }

        public void Adicionar(Lancamento lancamento)
        {
            using (var banco = new ContextoBase(_opcoesBuilder.Options))
            {
                banco.Set<Lancamento>().Add(lancamento);
                banco.SaveChanges();
            }
        }

        public List<Lancamento> Obter(string contaOrigem, string contaDestino, DateTimeOffset data)
        {
            using (var banco = new ContextoBase(_opcoesBuilder.Options))
            {
                // TODO - colocar parametros de filtro

                return banco.Set<Lancamento>().AsNoTracking().ToList();
            }
        }

        public Lancamento Obter(long id)
        {
            using (var banco = new ContextoBase(_opcoesBuilder.Options))
            {
                return banco.Set<Lancamento>().FirstOrDefault(x => x.Id == id);
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposed)
        {
            if (!disposed) return;
        }

        ~RepositorioDeLancamento()
        {
            Dispose(false);
        }
    }
}