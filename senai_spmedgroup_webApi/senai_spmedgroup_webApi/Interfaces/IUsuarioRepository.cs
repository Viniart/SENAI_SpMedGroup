using senai_spmedgroup_webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_spmedgroup_webApi.Interfaces
{
    interface IUsuarioRepository
    {
        List<Usuario> Listar();

        Usuario BuscarPorId(int id);

        void Cadastrar(Usuario entity);

        void Atualizar(int id, Usuario entity);

        void Deletar(int id);

        public Usuario BuscarPorEmailSenha(string email, string senha);
    }
}
