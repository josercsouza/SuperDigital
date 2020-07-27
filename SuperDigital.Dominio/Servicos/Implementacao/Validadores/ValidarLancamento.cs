using SuperDigital.Dominio.ObjetosDeValor;
using SuperDigital.Dominio.Repositorios;

namespace SuperDigital.Dominio.Servicos.Implementacao.Validadores
{
    public static class ValidarLancamento
    {
        public static bool Validar(LancamentoOV lancamentoOV, IRepositorioDeContaCorrente _repositorioDeContaCorrente)
        {
            if (string.IsNullOrEmpty(lancamentoOV.ContaOrigem)
                || string.IsNullOrEmpty(lancamentoOV.ContaDestino)
                || lancamentoOV.Valor == 0
                || lancamentoOV.ContaOrigem == lancamentoOV.ContaDestino)
                return false;
            else
            {
                var contaOrigem = _repositorioDeContaCorrente.Obter(lancamentoOV.ContaOrigem).Result;
                var contaDestino = _repositorioDeContaCorrente.Obter(lancamentoOV.ContaDestino).Result;

                return contaOrigem != null && contaDestino != null;
            }
        }
    }
}