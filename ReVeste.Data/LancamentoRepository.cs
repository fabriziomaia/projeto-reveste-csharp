using Microsoft.EntityFrameworkCore;
using ReVeste.Core;
using System.Collections.Generic;
using System.Linq;
using System;

namespace ReVeste.Data
{
    public class LancamentoRepository
    {
        private readonly ReVesteDbContext _context = new ReVesteDbContext();

        public void Adicionar(Lancamento lancamento)
        {
            _context.Lancamentos.Add(lancamento);
            _context.SaveChanges();
        }

        public List<Lancamento> ListarPorUsuario(int usuarioId)
        {
            return _context.Lancamentos
                .Where(l => l.UsuarioId == usuarioId)
                .OrderByDescending(l => l.Data)
                .ToList();
        }
    }
}