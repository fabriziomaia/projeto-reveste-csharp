using ReVeste.Business;
using ReVeste.Core;
using ReVeste.Data;
using System;
using System.Globalization;

public class Program
{
    private static readonly UsuarioRepository _usuarioRepository = new UsuarioRepository();
    private static readonly FinanceiroService _financeiroService = new FinanceiroService();
    private static Usuario? _usuarioLogado;

    public static void Main(string[] args)
    {
        CultureInfo.CurrentCulture = new CultureInfo("pt-BR");

        Console.WriteLine("Bem-vindo ao ReVeste!");
        _usuarioLogado = _usuarioRepository.GetOrCreateUser("Fabrizio", "fabrizio@email.com");
        Console.WriteLine($"Usuário '{_usuarioLogado.Nome}' carregado.");
        Console.WriteLine("Pressione qualquer tecla para continuar...");
        Console.ReadKey();

        bool sair = false;
        while (!sair)
        {
            Console.Clear();
            Console.WriteLine("--- Menu Principal ReVeste ---");
            Console.WriteLine($"Usuário: {_usuarioLogado.Nome}");
            Console.WriteLine("--------------------------------");
            Console.WriteLine("1. Registrar Gasto com Aposta");
            Console.WriteLine("2. Registrar Depósito em Investimento");
            Console.WriteLine("3. Ver Meu Dashboard");
            Console.WriteLine("4. Exportar Relatório Financeiro");
            Console.WriteLine("0. Sair");
            Console.Write("\nEscolha uma opção: ");

            switch (Console.ReadLine())
            {
                case "1":
                    RegistrarLancamento(TipoLancamento.Aposta);
                    break;
                case "2":
                    RegistrarLancamento(TipoLancamento.Investimento);
                    break;
                case "3":
                    MostrarDashboard();
                    break;
                case "4":
                    ExportarRelatorio();
                    break;
                case "0":
                    sair = true;
                    break;
                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }

            if (!sair)
            {
                Console.WriteLine("\nPressione qualquer tecla para voltar ao menu...");
                Console.ReadKey();
            }
        }
    }

    private static void RegistrarLancamento(TipoLancamento tipo)
    {
        if (_usuarioLogado == null) return;

        try
        {
            Console.WriteLine($"\n--- Registrar {tipo} ---");
            Console.Write("Descrição: ");
            string? descricao = Console.ReadLine();

            Console.Write("Valor (R$): ");
            decimal valor = decimal.Parse(Console.ReadLine() ?? "0");

            _financeiroService.RegistrarLancamento(_usuarioLogado.Id, valor, tipo, descricao);
            Console.WriteLine($"\n{tipo} registrada com sucesso!");
        }
        catch (FormatException)
        {
            Console.WriteLine("\nErro: Valor inválido. Por favor, use números e vírgula para decimais.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nOcorreu um erro: {ex.Message}");
        }
    }

    private static void MostrarDashboard()
    {
        if (_usuarioLogado == null) return;

        Console.Clear();
        Console.WriteLine("--- Seu Dashboard ReVeste ---");

        var totalApostas = _financeiroService.CalcularTotalPorTipo(_usuarioLogado.Id, TipoLancamento.Aposta);
        var totalInvestido = _financeiroService.CalcularTotalPorTipo(_usuarioLogado.Id, TipoLancamento.Investimento);
        var score = _financeiroService.CalcularScoreInteligenciaFinanceira(totalApostas, totalInvestido);
        var custoOportunidade = _financeiroService.SimularCustoDeOportunidade(totalApostas);

        Console.WriteLine($"Total gasto em apostas: {totalApostas:C}");
        Console.WriteLine($"Total investido: {totalInvestido:C}");
        Console.WriteLine($"Custo de Oportunidade: Seu dinheiro em apostas poderia ter rendido aproximadamente {custoOportunidade:C} este mês.");
        Console.WriteLine("\n--------------------------------");
        Console.WriteLine($"Score de Inteligência Financeira: {score:F1}");

        if (score > 75) Console.WriteLine("Status: Excelente! Você está no caminho certo para a independência financeira.");
        else if (score > 50) Console.WriteLine("Status: Bom. Você está começando a investir mais do que aposta.");
        else if (score > 25) Console.WriteLine("Status: Alerta. Seu volume de apostas ainda é significativo. Continue focando nos investimentos!");
        else Console.WriteLine("Status: Risco. A maior parte dos seus recursos está indo para apostas. ReVeste está aqui para ajudar a mudar isso!");
    }

    private static void ExportarRelatorio()
    {
        if (_usuarioLogado == null) return;

        try
        {
            Console.WriteLine("\nExportando relatório para os formatos JSON e TXT...");
            _financeiroService.GerarRelatorioFinanceiro(_usuarioLogado.Id);
            Console.WriteLine("Exportação concluída com sucesso!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nOcorreu um erro ao exportar: {ex.Message}");
        }
    }
}