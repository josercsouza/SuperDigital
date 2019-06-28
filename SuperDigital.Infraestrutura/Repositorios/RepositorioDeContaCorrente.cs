using Microsoft.EntityFrameworkCore;
using SuperDigital.Dominio.Entidades;
using SuperDigital.Dominio.Repositorios;
using SuperDigital.Infraestrutura.Contexto;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SuperDigital.Infraestrutura.Repositorios
{
    public class RepositorioDeContaCorrente : IRepositorioDeContaCorrente, IDisposable
    {
        private readonly DbContextOptionsBuilder<ContextoBase> _optionsBuilder;

        public RepositorioDeContaCorrente()
        {
            _optionsBuilder = new DbContextOptionsBuilder<ContextoBase>();
        }

        public void Adicionar(ContaCorrente contaCorrente)
        {
            using (var banco = new ContextoBase(_optionsBuilder.Options))
            {
                banco.Set<ContaCorrente>().Add(contaCorrente);
                banco.SaveChanges();
            }
        }

        public void Alterar(ContaCorrente contaCorrente)
        {
            using (var banco = new ContextoBase(_optionsBuilder.Options))
            {
                banco.Set<ContaCorrente>().Update(contaCorrente);
                banco.SaveChanges();
            }
        }

        public void Excluir(ContaCorrente contaCorrente)
        {
            using (var banco = new ContextoBase(_optionsBuilder.Options))
            {
                banco.Set<ContaCorrente>().Remove(contaCorrente);
                banco.SaveChanges();
            }
        }

        public List<ContaCorrente> ObterPorNome(string nome)
        {
            using (var banco = new ContextoBase(_optionsBuilder.Options))
            {
                return banco.Set<ContaCorrente>().AsNoTracking().Where(x=>x.NomeDoCorrentista.Contains(nome)).ToList();
            }
        }

        public ContaCorrente Obter(string numeroDaConta)
        {
            using (var banco = new ContextoBase(_optionsBuilder.Options))
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