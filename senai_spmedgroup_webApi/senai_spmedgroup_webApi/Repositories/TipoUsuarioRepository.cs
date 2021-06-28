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
    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {
        SpMedGroupContext _context = new SpMedGroupContext();

        public void Atualizar(int id, TiposUsuario tipoAtualizado)
        {
            TiposUsuario tipoBuscado = _context.TiposUsuarios.Find(id);

            if (tipoAtualizado.TiposUsuario1 != null)
            {
                tipoBuscado.TiposUsuario1 = tipoAtualizado.TiposUsuario1;
            }

            _context.TiposUsuarios.Update(tipoBuscado);

            _context.SaveChanges();
        }

        public TiposUsuario BuscarPorId(int id)
        {
            return _context.TiposUsuarios.FirstOrDefault(e => e.IdTiposUsuario == id);
        }

        public void Cadastrar(TiposUsuario entity)
        {
            _context.TiposUsuarios.Add(entity);

            _context.SaveChanges();
        }

        public void Deletar(int id)
        {
            TiposUsuario tipoBuscado = BuscarPorId(id);

            _context.TiposUsuarios.Remove(tipoBuscado);

            _context.SaveChanges();
        }

        public List<TiposUsuario> Listar()
        {
            return _context.TiposUsuarios.ToList();
        }
    }
}
