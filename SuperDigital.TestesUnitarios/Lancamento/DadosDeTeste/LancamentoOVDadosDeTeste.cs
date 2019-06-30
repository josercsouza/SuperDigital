using SuperDigital.Dominio.ObjetosDeValor;
using Xunit;

namespace SuperDigital.TestesUnitarios.Lancamento.DadosDeTeste
{
    public class LancamentoOVDadosDeTeste : TheoryData<LancamentoOV>
    {
        public LancamentoOVDadosDeTeste()
        {
            // Sem conta origem
            Add(new LancamentoOV
            {
                ContaOrigem = "",
                ContaDestino = "13",
                Valor = 1
            });

            // sem conta destino
            Add(new LancamentoOV
            {
                ContaOrigem = "12",
                ContaDestino = "",
                Valor = 1
            });

            // sem valor
            Add(new LancamentoOV
            {
                ContaOrigem = "12",
                ContaDestino = "13",
                Valor = 0
            });

            // conta origem e destino iguais
            Add(new LancamentoOV
            {
                ContaOrigem = "12",
                ContaDestino = "12",
                Valor = 1
            });

            // conta origem nao existe
            Add(new LancamentoOV
            {
                ContaOrigem = "123",
                ContaDestino = "13",
                Valor = 1
            });

            // conta destino nao existe
            Add(new LancamentoOV
            {
                ContaOrigem = "12",
                ContaDestino = "134",
                Valor = 1
            });
        }
    }
}