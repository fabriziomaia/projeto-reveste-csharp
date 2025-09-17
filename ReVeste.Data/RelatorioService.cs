using ReVeste.Core;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Linq;
using System;

namespace ReVeste.Data
{
    public class RelatorioService
    {
        public void ExportarParaJson(int usuarioId, List<Lancamento> lancamentos)
        {
            string fileName = $"Relatorio_ReVeste_{usuarioId}_{DateTime.Now:yyyyMMdd}.json";
            string jsonString = JsonSerializer.Serialize(lancamentos, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(fileName, jsonString);
            Console.WriteLine($"Relatório salvo em: {Path.GetFullPath(fileName)}");
        }

        public void ExportarParaTxt(int usuarioId, List<Lancamento> lancamentos, decimal totalApostas, decimal totalInvestido, double score)
        {
            string fileName = $"Relatorio_ReVeste_{usuarioId}_{DateTime.Now:yyyyMMdd}.txt";
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                writer.WriteLine("--- Relatório Financeiro ReVeste ---");
                writer.WriteLine($"Data de Emissão: {DateTime.Now:dd/MM/yyyy HH:mm}");
                writer.WriteLine("--------------------------------------");
                writer.WriteLine($"Total Gasto em Apostas: {totalApostas:C}");
                writer.WriteLine($"Total Investido: {totalInvestido:C}");
                writer.WriteLine($"Score de Inteligência Financeira: {score:F1}");
                writer.WriteLine("--------------------------------------");
                writer.WriteLine("\nHistórico de Lançamentos:");

                foreach (var lancamento in lancamentos.OrderBy(l => l.Data))
                {
                    writer.WriteLine($" - [{lancamento.Data:dd/MM/yy}] {lancamento.Tipo}: {lancamento.Valor:C} ({lancamento.Descricao})");
                }
            }
            Console.WriteLine($"Relatório salvo em: {Path.GetFullPath(fileName)}");
        }
    }
}