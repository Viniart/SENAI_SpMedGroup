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
    public class ConsultaRepository : IConsultaRepository
    {
        SpMedGroupContext _context = new SpMedGroupContext();
        public void Atualizar(int id, Consulta consultaAtualizada)
        {
            Consulta consultaBuscada = _context.Consultas.Find(id);

            if (consultaAtualizada.IdConsulta > 0)
            {
                consultaBuscada.DataConsulta = consultaAtualizada.DataConsulta;
                consultaBuscada.Descricao = consultaAtualizada.Descricao;
                consultaBuscada.IdPaciente = consultaAtualizada.IdPaciente;
                consultaBuscada.IdMedico = consultaAtualizada.IdPaciente;
                consultaBuscada.IdSituacao = consultaAtualizada.IdSituacao;
            }

            _context.Consultas.Update(consultaBuscada);

            _context.SaveChanges();
        }

        public void AtualizarDescricao(int id, string descricao)
        {
            Consulta consultaBuscada = _context.Consultas
                .Include(p => p.IdMedicoNavigation)
                .Include(p => p.IdPacienteNavigation)
                .Include(p => p.IdSituacaoNavigation)
                .FirstOrDefault(p => p.IdConsulta == id);

            consultaBuscada.Descricao = descricao;

            _context.Consultas.Update(consultaBuscada);

            _context.SaveChanges();
        }

        public Consulta BuscarPorId(int id)
        {
            return _context.Consultas.FirstOrDefault(e => e.IdConsulta == id);
        }

        public List<Consulta> BuscarPorMedico(int id)
        {

            List<Consulta> Consultas = _context.Consultas
                .Include(x => x.IdMedicoNavigation)
                .Include(x => x.IdPacienteNavigation)
                .Include(x => x.IdSituacaoNavigation)
                .Where(e => e.IdMedico == id)
                .Select(x => new Consulta()
                {
                    IdConsulta = x.IdConsulta,
                    IdPaciente = x.IdPaciente,
                    IdSituacao = x.IdSituacao,
                    IdMedico = x.IdMedico,
                    DataConsulta = x.DataConsulta,
                    Descricao = x.Descricao,
                    IdMedicoNavigation = new Medico()
                    {
                        Nome = x.IdMedicoNavigation.Nome,
                        IdEspecialidade = x.IdMedicoNavigation.IdEspecialidade,
                        IdUsuario = x.IdMedicoNavigation.IdUsuario
                    },
                    IdPacienteNavigation = new Paciente()
                    {
                        Nome = x.IdPacienteNavigation.Nome,
                        IdUsuario = x.IdPacienteNavigation.IdUsuario
                    },
                    IdSituacaoNavigation = new SituacaoConsulta()
                    {
                        IdSituacao = x.IdSituacaoNavigation.IdSituacao,
                        Situacao = x.IdSituacaoNavigation.Situacao
                    }
                }
                )
                .ToList();
            return Consultas;
            //return _context.Consultas
            //       .Include(e => e.IdMedicoNavigation)
            //       .Include(e => e.IdPacienteNavigation)
            //       .Include(e => e.IdSituacaoNavigation)
            //       .Where(e => e.IdMedico == idMedico)
            //       .ToList();
        }

        public List<Consulta> BuscarPorPaciente(int idPaciente)
        {

            List<Consulta> Consultas = _context.Consultas
                .Include(x => x.IdMedicoNavigation)
                .Include(x => x.IdPacienteNavigation)
                .Include(x => x.IdSituacaoNavigation)
                .Where(e => e.IdPaciente == idPaciente)
                .Select(x => new Consulta()
                {
                    IdConsulta = x.IdConsulta,
                    IdPaciente = x.IdPaciente,
                    IdSituacao = x.IdSituacao,
                    IdMedico = x.IdMedico,
                    DataConsulta = x.DataConsulta,
                    Descricao = x.Descricao,
                    IdMedicoNavigation = new Medico()
                    {
                        Nome = x.IdMedicoNavigation.Nome,
                        IdEspecialidade = x.IdMedicoNavigation.IdEspecialidade,
                        IdUsuario = x.IdMedicoNavigation.IdUsuario
                    },
                    IdPacienteNavigation = new Paciente()
                    {
                        Nome = x.IdPacienteNavigation.Nome,
                        IdUsuario = x.IdPacienteNavigation.IdUsuario
                    },
                    IdSituacaoNavigation = new SituacaoConsulta()
                    {
                        IdSituacao = x.IdSituacaoNavigation.IdSituacao,
                        Situacao = x.IdSituacaoNavigation.Situacao
                    }
                }
                ).ToList();
            return Consultas;
        }

        public void Cadastrar(Consulta entity)
        {
            _context.Consultas.Add(entity);

            _context.SaveChanges();
        }

        public void Deletar(int id)
        {
            Consulta consultaBuscada = _context.Consultas.Find(id);

            _context.Consultas.Remove(consultaBuscada);

            _context.SaveChanges();
        }

        public List<Consulta> Listar()
        {
            //return _context.Consultas
            //    .Include(e => e.IdMedicoNavigation)
            //    .Include(e => e.IdPacienteNavigation)
            //    .Include(e => e.IdSituacaoNavigation)
            //    .ToList();
            List<Consulta> Consultas = _context.Consultas
                .Include(x => x.IdMedicoNavigation)
                .Include(x => x.IdPacienteNavigation)
                .Include(x => x.IdSituacaoNavigation)
                .Select(x => new Consulta()
                {
                    IdConsulta = x.IdConsulta,
                    IdPaciente = x.IdPaciente,
                    IdSituacao = x.IdSituacao,
                    IdMedico = x.IdMedico,
                    DataConsulta = x.DataConsulta,
                    Descricao = x.Descricao,
                    IdMedicoNavigation = new Medico()
                    {
                        Nome = x.IdMedicoNavigation.Nome,
                        IdEspecialidade = x.IdMedicoNavigation.IdEspecialidade,
                        IdUsuario = x.IdMedicoNavigation.IdUsuario
                    },
                    IdPacienteNavigation = new Paciente()
                    {
                        Nome = x.IdPacienteNavigation.Nome,
                        IdUsuario = x.IdPacienteNavigation.IdUsuario
                    },
                    IdSituacaoNavigation = new SituacaoConsulta()
                    {
                        IdSituacao = x.IdSituacaoNavigation.IdSituacao,
                        Situacao = x.IdSituacaoNavigation.Situacao
                    }
                }
                ).ToList();
            return Consultas;
        }
        public int BuscarIdPaciente(int id)
        {
            var paciente = _context.Pacientes.FirstOrDefault(c => c.IdUsuario == id);

            return paciente.IdPaciente;
        }
        public int BuscarIdMedico(int id)
        {
            var medico = _context.Medicos.FirstOrDefault(c => c.IdUsuario == id);

            return medico.IdMedico;
        }
    }
}
