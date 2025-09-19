using ReVeste.Core;
using ReVeste.Data;
using System.Collections.Generic;
using System.Linq;
using System;

namespace ReVeste.Business
{
    public class FinanceiroService
    {
        private readonly LancamentoRepository _lancamentoRepository = new LancamentoRepository();
        private readonly RelatorioService _relatorioService = new RelatorioService();

        public void RegistrarLancamento(int usuarioId, decimal valor, TipoLancamento tipo, string? descricao)
        {
            if (valor <= 0)
            {
                throw new ArgumentException("O valor do lançamento deve ser positivo.");
            }

            var lancamento = new Lancamento
            {
                UsuarioId = usuarioId,
                Valor = valor,
                Tipo = tipo,
                Descricao = descricao,
                Data = DateTime.Now
            };
            _lancamentoRepository.Adicionar(lancamento);
        }

        public List<Lancamento> ObterLancamentosDoUsuario(int usuarioId)
        {
            return _lancamentoRepository.ListarPorUsuario(usuarioId);
        }

        public decimal CalcularTotalPorTipo(int usuarioId, TipoLancamento tipo)
        {
            return _lancamentoRepository.ListarPorUsuario(usuarioId)
                .Where(l => l.Tipo == tipo)
                .Sum(l => l.Valor);
        }

        public double CalcularScoreInteligenciaFinanceira(decimal totalApostas, decimal totalInvestido)
        {
            if (totalApostas + totalInvestido == 0)
            {
                return 0;
            }
            double score = (double)(totalInvestido / (totalApostas + totalInvestido)) * 100;
            return score;
        }

        public decimal SimularCustoDeOportunidade(decimal totalApostas)
        {
            const decimal taxaDeRendimentoMensal = 0.008m;
            return totalApostas * taxaDeRendimentoMensal;
        }

        public void GerarRelatorioFinanceiro(int usuarioId)
        {
            var lancamentos = ObterLancamentosDoUsuario(usuarioId);
            var totalApostas = lancamentos.Where(l => l.Tipo == TipoLancamento.Aposta).Sum(l => l.Valor);
            var totalInvestido = lancamentos.Where(l => l.Tipo == TipoLancamento.Investimento).Sum(l => l.Valor);
            var score = CalcularScoreInteligenciaFinanceira(totalApostas, totalInvestido);

            _relatorioService.ExportarParaJson(usuarioId, lancamentos);
            _relatorioService.ExportarParaTxt(usuarioId, lancamentos, totalApostas, totalInvestido, score);
        }
    }
}