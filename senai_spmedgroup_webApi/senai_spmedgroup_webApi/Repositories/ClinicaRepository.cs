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
    public class ClinicaRepository : IClinicaRepository
    {
        SpMedGroupContext _context = new SpMedGroupContext();
        public void Atualizar(int id, Clinica ClinicaAtualizada)
        {
            Clinica clinicaBuscada = _context.Clinicas.Find(id);

            if (ClinicaAtualizada.Cnpj != null)
            {
                clinicaBuscada.Cnpj = ClinicaAtualizada.Cnpj;
                clinicaBuscada.Endereco = ClinicaAtualizada.Endereco;
                clinicaBuscada.NomeFantasia = ClinicaAtualizada.NomeFantasia;
                clinicaBuscada.RazaoSocial = ClinicaAtualizada.RazaoSocial;
                clinicaBuscada.HorarioAbertura = ClinicaAtualizada.HorarioAbertura;
                clinicaBuscada.HorarioFechamento = ClinicaAtualizada.HorarioFechamento;

            _context.Clinicas.Update(clinicaBuscada);

            _context.SaveChanges();
            }
        }

        public Clinica BuscarPorId(int id)
        {
            return _context.Clinicas.FirstOrDefault(e => e.IdClinica == id);
        }

        public void Cadastrar(Clinica novaClinica)
        {
            _context.Clinicas.Add(novaClinica);
        }

        public void Deletar(int id)
        {
            Clinica clinicaBuscada = _context.Clinicas.Find(id);

            _context.Clinicas.Remove(clinicaBuscada);

            _context.SaveChanges();
        }

        public List<Clinica> Listar()
        {
            return _context.Clinicas.Include(e => e.Medicos).ToList();
        }
    }
}
