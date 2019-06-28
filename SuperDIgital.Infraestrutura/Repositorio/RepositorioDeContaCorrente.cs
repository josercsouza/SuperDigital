using Microsoft.EntityFrameworkCore;
using SuperDigital.Dominio.Entidades;
using SuperDigital.Dominio.Interfaces;
using SuperDIgital.Infraestrutura.Contexto;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SuperDIgital.Infraestrutura.Repositorio
{
    public class RepositorioDeContaCorrente : IRepositorioDeContaCorrente, IDisposable
    {
        private readonly DbContextOptionsBuilder<ContextoBase> _opcoesBuilder;

        public RepositorioDeContaCorrente()
        {
            _opcoesBuilder = new DbContextOptionsBuilder<ContextoBase>();
        }

        public void Adicionar(ContaCorrente contaCorrente)
        {
            using (var banco = new ContextoBase(_opcoesBuilder.Options))
            {
                banco.Set<ContaCorrente>().Add(contaCorrente);
                banco.SaveChanges();
            }
        }

        public void Alterar(ContaCorrente contaCorrente)
        {
            using (var banco = new ContextoBase(_opcoesBuilder.Options))
            {
                banco.Set<ContaCorrente>().Update(contaCorrente);
                banco.SaveChanges();
            }
        }

        public void Excluir(ContaCorrente contaCorrente)
        {
            using (var banco = new ContextoBase(_opcoesBuilder.Options))
            {
                banco.Set<ContaCorrente>().Remove(contaCorrente);
                banco.SaveChanges();
            }
        }

        public List<ContaCorrente> Obter(string nome, decimal saldo)
        {
            using (var banco = new ContextoBase(_opcoesBuilder.Options))
            {
                // TODO - colocar parametros de filtro

                return banco.Set<ContaCorrente>().AsNoTracking().ToList();
            }
        }

        public ContaCorrente Obter(string numeroDaConta)
        {
            using (var banco = new ContextoBase(_opcoesBuilder.Options))
            {
                return banco.Set<ContaCorrente>().FirstOrDefault(x => x.NumeroDaConta == numeroDaConta);
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

        ~RepositorioDeContaCorrente()
        {
            Dispose(false);
        }
    }
}