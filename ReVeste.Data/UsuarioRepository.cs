using ReVeste.Core;
using System.Linq;

namespace ReVeste.Data
{
    public class UsuarioRepository
    {
        private readonly ReVesteDbContext _context = new ReVesteDbContext();

        public Usuario GetOrCreateUser(string nome, string email)
        {
            var usuario = _context.Usuarios.FirstOrDefault(u => u.Email == email);

            if (usuario == null)
            {
                usuario = new Usuario { Nome = nome, Email = email };
                _context.Usuarios.Add(usuario);
                _context.SaveChanges();
            }
            return usuario;
        }
    }
}