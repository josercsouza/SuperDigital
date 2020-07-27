using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SuperDigital.Dominio.Entidades;
using SuperDigital.Dominio.Repositorios;
using SuperDigital.Infraestrutura.Contexto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperDigital.Infraestrutura.Repositorios
{
    public class RepositorioDeAutorizacao : IRepositorioDeAutorizacao
    {
        private readonly DbContextOptionsBuilder<ContextoBase> _optionsBuilder;

        public RepositorioDeAutorizacao() =>
            _optionsBuilder = new DbContextOptionsBuilder<ContextoBase>();

        public void Adicionar(Autorizacao autorizacao)
        {
            using var contexto = new ContextoBase(_optionsBuilder.Options);
            contexto.Set<Autorizacao>().Add(autorizacao);
            contexto.SaveChangesAsync();
        }

        public async Task<List<Autorizacao>> OldObterClientesIrregulares()
        {
            using var contexto = new ContextoBase(_optionsBuilder.Options);
            var consulta = contexto.Set<Autorizacao>().AsNoTracking().AsQueryable();

            consulta = consulta.Where(x => x.Validado);
            consulta = (IQueryable<Autorizacao>)consulta.GroupBy(x => x.CodigoDeIndentificacao);

            var retorno = consulta.ToListAsync();

            return await retorno;
        }

        public async Task<Autorizacao> Obter(Guid codigo)
        {
            using var contexto = new ContextoBase(_optionsBuilder.Options);
            return await contexto.Set<Autorizacao>().FirstOrDefaultAsync(x => x.Codigo == codigo).ConfigureAwait(false);
        }

        public async Task<List<Autorizacao>> ObterClientesIrregulares()
        {
            using var contexto = new ContextoBase(_optionsBuilder.Options);
            using var conexao = new SqlConnection(contexto.StringConectionConfig());

            const string sql = @"SELECT *
                                 FROM [dbo].[Autorizacao]
                                 WHERE DataDeRevalidacao IS NULL
                                 AND CONCAT(CodigoDeIndentificacao, DataDeExpiracao) IN
                                 (
                                 	SELECT CONCAT(CodigoDeIndentificacao, MAX(DataDeExpiracao))
                                 	FROM [dbo].[Autorizacao]
                                 	WHERE Validado = 1
                                 	GROUP BY CodigoDeIndentificacao
                                 	HAVING GETDATE() > MAX(DataDeExpiracao)
                                 )
                                 ORDER BY DataDeExpiracao";

            Task<IEnumerable<Autorizacao>> retorno = conexao.QueryAsync<Autorizacao>(sql);

            return (List<Autorizacao>)await retorno.ConfigureAwait(false);
        }
    }
}