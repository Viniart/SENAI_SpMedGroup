using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai_spmedgroup_webApi.Domains;
using senai_spmedgroup_webApi.Interfaces;
using senai_spmedgroup_webApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_spmedgroup_webApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ClinicasController : ControllerBase
    {
        private IClinicaRepository _clinicasRepository { get; set; }

        public ClinicasController()
        {
            _clinicasRepository = new ClinicaRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_clinicasRepository.Listar());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_clinicasRepository.BuscarPorId(id));
        }

        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Post(Clinica novaClinica)
        {
            _clinicasRepository.Cadastrar(novaClinica);

            return StatusCode(201);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Clinica clinicaAtualizada)
        {
            _clinicasRepository.Atualizar(id, clinicaAtualizada);

            return StatusCode(204);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _clinicasRepository.Deletar(id);

            return StatusCode(204);
        }
    }
}
