using Microsoft.EntityFrameworkCore;
using ReVeste.Core;
using System.IO;
using System;

namespace ReVeste.Data
{
    public class ReVesteDbContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Lancamento> Lancamentos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // CORREÇÃO: Adicionado '!' para suprimir os avisos de possível nulo.
            string solutionFolderPath = Directory.GetParent(AppContext.BaseDirectory)!.Parent!.Parent!.Parent!.FullName;
            string dbPath = Path.Combine(solutionFolderPath, "reveste.db");
            
            optionsBuilder.UseSqlite($"Data Source={dbPath}");
        }
    }
}