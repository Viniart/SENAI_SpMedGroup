using senai_spmedgroup_webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_spmedgroup_webApi.Interfaces
{
    interface ITipoUsuarioRepository
    {
        List<TiposUsuario> Listar();

        TiposUsuario BuscarPorId(int id);

        void Cadastrar(TiposUsuario entity);

        void Atualizar(int id, TiposUsuario entity);

        void Deletar(int id);
    }
}
