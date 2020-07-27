using Moq;
using SuperDigital.Dominio.Entidades;
using SuperDigital.Dominio.ObjetosDeValor;
using SuperDigital.Dominio.Repositorios;
using SuperDigital.Dominio.Servicos.Implementacao.Validadores;
using SuperDigital.TestesUnitarios.Lancamento.DadosDeTeste;
using Xunit;

namespace SuperDigital.TestesUnitarios.Lancamento.Validadores
{
    public partial class ValidadoresLancamento
    {
        public class MetodoValidarLancamento
        {
            [Fact]
            public void QuandoTodosOsAtributosForamInformadosCorretamente()
            {
                //Arrange
                var lancamentoOV = new LancamentoOV()
                {
                    ContaOrigem = "12",
                    ContaDestino = "13",
                    Valor = 1
                };

                var mock = new Mock<IRepositorioDeContaCorrente>();
                mock.Setup(x => x.Obter(lancamentoOV.ContaOrigem))
                    .ReturnsAsync(new ContaCorrente()
                    {
                        NumeroDaConta = "12"
                    });
                mock.Setup(x => x.Obter(lancamentoOV.ContaDestino))
                    .ReturnsAsync(new ContaCorrente()
                    {
                        NumeroDaConta = "13"
                    });

                // Act
                var resultado = ValidarLancamento.Validar(lancamentoOV, mock.Object);

                // Assert
                Assert.True(resultado);
            }

            [Theory]
            [ClassData(typeof(LancamentoOVDadosDeTeste))]
            public void QuandoAlgumAtributoNaoForInformadoCorretamenteRetornaFalse(LancamentoOV lancamentoOV)
            {
                //Arrange
                var mock = new Mock<IRepositorioDeContaCorrente>();

                if (lancamentoOV.ContaOrigem == "12")
                    mock.Setup(x => x.Obter(lancamentoOV.ContaOrigem))
                        .ReturnsAsync(lancamentoOV.ContaOrigem == "12"
                        ? new ContaCorrente()
                        {
                            NumeroDaConta = "12"
                        }
                        : null);

                if (lancamentoOV.ContaDestino == "13")
                    mock.Setup(x => x.Obter(lancamentoOV.ContaDestino))
                        .ReturnsAsync(lancamentoOV.ContaDestino == "13"
                        ? new ContaCorrente()
                        {
                            NumeroDaConta = "13"
                        }
                        : null);

                // Act
                var resultado = ValidarLancamento.Validar(lancamentoOV, mock.Object);

                // Assert
                Assert.False(resultado);
            }
        }
    }
}