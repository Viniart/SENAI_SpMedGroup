using Microsoft.EntityFrameworkCore;
using senai_spmedgroup_webApi.Contexts;
using senai_spmedgroup_webApi.Domains;
using senai_spmedgroup_webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_spmedgroup_webApi.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        SpMedGroupContext _context = new SpMedGroupContext();
        public void Atualizar(int id, Usuario usuarioAtualizado)
        {
            Usuario usuarioBuscado = _context.Usuarios.Find(id);

            if (usuarioAtualizado.Email != null)
            {
                usuarioBuscado.Email = usuarioAtualizado.Email;
                usuarioBuscado.Senha = usuarioAtualizado.Senha;
                usuarioBuscado.IdTiposUsuario = usuarioAtualizado.IdTiposUsuario;
            }

            _context.Usuarios.Update(usuarioBuscado);

            _context.SaveChanges();
        }

        public Usuario BuscarPorEmailSenha(string email, string senha)
        {
            Usuario usuarioLogin = _context.Usuarios.Include(e => e.IdTiposUsuarioNavigation).FirstOrDefault(e => e.Email == email && e.Senha == senha);

            if (usuarioLogin.Email != null)
            {
                return usuarioLogin;
            }

            return null;
        }

        public Usuario BuscarPorId(int id)
        {
            return _context.Usuarios.FirstOrDefault(e => e.IdUsuario == id);
        }

        public void Cadastrar(Usuario novoUsuario)
        {
            _context.Usuarios.Add(novoUsuario);
        }

        public void Deletar(int id)
        {
            Usuario usuarioBuscado = _context.Usuarios.Find(id);

            _context.Usuarios.Remove(usuarioBuscado);

            _context.SaveChanges();
        }

        public List<Usuario> Listar()
        {
            return _context.Usuarios.Include(e => e.IdTiposUsuarioNavigation).ToList();
        }
    }
}
