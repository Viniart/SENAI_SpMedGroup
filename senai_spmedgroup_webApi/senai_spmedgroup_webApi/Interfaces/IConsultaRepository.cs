using senai_spmedgroup_webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_spmedgroup_webApi.Interfaces
{
    interface IConsultaRepository
    {
        List<Consulta> Listar();

        Consulta BuscarPorId(int id);

        List<Consulta> BuscarPorMedico(int id);

        List<Consulta> BuscarPorPaciente(int id);

        void Cadastrar(Consulta entity);

        void Atualizar(int id, Consulta entity);

        void AtualizarDescricao(int id, string entity);

        void Deletar(int id);

        // Métodos de Apoio (Seria bom separar deste repository)
        int BuscarIdPaciente(int id);

        int BuscarIdMedico(int id);
    }
}
