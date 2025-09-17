# Projeto ReVeste - Transformando Apostas em Investimentos

![Status: MVP Concluído](https://img.shields.io/badge/status-MVP%20Concluído-brightgreen?style=for-the-badge)  
![Linguagem: C#](https://img.shields.io/badge/csharp-%23239120.svg?style=for-the-badge&logo=c-sharp&logoColor=white)  
![Plataforma: .NET 8](https://img.shields.io/badge/.NET-8-5C2D91?style=for-the-badge&logo=.net&logoColor=white)  
![Licença: MIT](https://img.shields.io/badge/License-MIT-yellow.svg?style=for-the-badge)

> [cite_start]Uma ferramenta transformadora que capacita, apoia e motiva usuários a redirecionarem suas "apostas" para um futuro financeiro mais seguro e próspero[cite: 183].

---

## 📖 Tabela de Conteúdos

1. [Visão Geral do Projeto](#-visão-geral-do-projeto)  
2. [📸 Demonstração Visual](#-demonstração-visual)  
3. [✨ Funcionalidades Principais](#-funcionalidades-principais)  
4. [🏗️ Arquitetura e Fluxo de Execução](#️-arquitetura-e-fluxo-de-execução)  
5. [🛠️ Tecnologias Utilizadas](#️-tecnologias-utilizadas)  
6. [▶️ Como Executar o Projeto](#️-como-executar-o-projeto)  
7. [🤝 Como Contribuir](#-como-contribuir)  
8. [📜 Licença](#-licença)  
9. [✍️ Autor](#️-autor)  

---

## 🎯 Visão Geral do Projeto

O **ReVeste** é uma plataforma inovadora que atua na interseção entre saúde financeira, prevenção ao vício em apostas e educação financeira prática.  
[cite_start]Diante do crescimento exponencial de plataformas de apostas online no Brasil[cite: 9], o projeto surge como uma solução para um problema social e financeiro significativo.  
[cite_start]O objetivo principal é capacitar indivíduos a transformar hábitos de apostas em oportunidades de investimento [cite: 35][cite_start], promovendo a saúde financeira e prevenindo o vício[cite: 36].

Esta implementação representa o **MVP (Minimum Viable Product)** do núcleo do sistema, desenvolvido como uma aplicação de console em C#.  
A solução simula as funcionalidades centrais da plataforma ReVeste, como o registro de lançamentos, o cálculo do Score de Inteligência Financeira e a geração de relatórios.

---

## 📸 Demonstração Visual

Abaixo, uma simulação da tela principal do Dashboard no console:

--- Seu Dashboard ReVeste ---
Total gasto em apostas: R$ 500,00
Total investido: R$ 800,00
Custo de Oportunidade: Seu dinheiro em apostas poderia ter rendido aproximadamente R$ 4,00 este mês.

Score de Inteligência Financeira: 78
Status: Excelente! Você está no caminho certo para a independência financeira.

---

## ✨ Funcionalidades Principais

- **Registro de Lançamentos:** Permite ao usuário registrar seus gastos com apostas e seus aportes em investimentos.  
- **Dashboard de Conscientização:** Exibe um painel com o total gasto em apostas versus o total investido, mostrando também o custo de oportunidade[cite: 38].  
- **Score de Inteligência Financeira:** Sistema de pontuação baseado na proporção entre investimentos e apostas, gamificando a jornada financeira[cite: 51, 55].  
- **Simulação de Custo de Oportunidade:** Estimativa de quanto o dinheiro gasto em apostas poderia ter rendido.  
- **Exportação de Relatórios:** Geração de relatórios nos formatos `.json` e `.txt`.  

---

## 🏗️ Arquitetura e Fluxo de Execução

### 🔹 Diagrama de Camadas

O projeto segue uma arquitetura em **4 camadas**, inspirada em princípios como **TOGAF** e **ArchiMate**, promovendo baixo acoplamento e escalabilidade[cite: 132].

```mermaid
graph TD
    UI(Presentation Layer <br> ReVeste.ConsoleApp) --> BLL(Business Logic Layer <br> ReVeste.Business)
    BLL --> DAL(Data Access Layer <br> ReVeste.Data)
    DAL --> DB[(Banco de Dados <br> SQLite / PostgreSQL)]
    DAL --> FS[(Sistema de Arquivos <br> Relatórios .json/.txt)]
    BLL --> Core(Core/Domain <br> ReVeste.Core)
    DAL --> Core

### 🔹 Fluxo de Execução (Exemplo: Registrar uma Aposta)
ReVeste.ConsoleApp: Recebe a entrada do usuário (descrição e valor da aposta).

ReVeste.Business: O FinanceiroService valida os dados e cria um objeto Lancamento.

ReVeste.Data: O LancamentoRepository utiliza o ReVesteDbContext do Entity Framework Core.

EF Core: Traduz o objeto em um comando SQL INSERT e o executa no banco reveste.db.

---

## 🛠️ Tecnologias Utilizadas
Linguagem: C# 12

Plataforma: .NET 8

ORM: Entity Framework Core 8

Banco de Dados: SQLite (menção a PostgreSQL no design original)

IDE: Visual Studio Code

---

## ▶️ Como Executar o Projeto
###🔹 Pré-requisitos
.NET 8 SDK

Visual Studio Code

Extensão C# Dev Kit para VS Code

###🔹 Passos para Instalação

Clone o repositório:
```bash
git clone [URL_DO_SEU_REPOSITORIO_GIT]
cd nome-da-pasta-do-projeto

Restaure as dependências:
```bash
dotnet restore

Crie e aplique as migrações do banco de dados:
(Este comando cria o arquivo reveste.db na raiz do projeto)
```bash
dotnet ef database update --project ReVeste.Data --startup-project ReVeste.ConsoleApp

Execute a aplicação:
```bash
dotnet run --project ReVeste.ConsoleApp

---

## 🤝 Como Contribuir
Faça um Fork do projeto.

Crie uma branch com sua feature: git checkout -b minha-feature.

Commit suas mudanças: git commit -m 'Minha nova feature'.

Faça o Push: git push origin minha-feature.

Abra um Pull Request.

---

## 📜 Licença
Este projeto está licenciado sob a Licença MIT.

---

## ✍️ Autor
Fabrizio