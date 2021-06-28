using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai_spmedgroup_webApi.Domains;
using senai_spmedgroup_webApi.Interfaces;
using senai_spmedgroup_webApi.Repositories;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace senai_spmedgroup_webApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultasController : ControllerBase
    {
        private IConsultaRepository _consultasRepository { get; set; }

        public ConsultasController()
        {
            _consultasRepository = new ConsultaRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_consultasRepository.Listar());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_consultasRepository.BuscarPorId(id));
        }

        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Post(Consulta novaConsulta)
        {
            _consultasRepository.Cadastrar(novaConsulta);

            return StatusCode(201);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Consulta consultaAtualizada)
        {
            _consultasRepository.Atualizar(id, consultaAtualizada);

            return StatusCode(204);
        }

        [Authorize(Roles = "1")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _consultasRepository.Deletar(id);

            return StatusCode(204);
        }

        [HttpGet("paciente")]
        public IActionResult GetMyP()
        {
            try
            {
                // Converter idUsuario para IdPaciente
                int idJti = Convert.ToInt32(HttpContext.User.Claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Jti).Value);
                int idPaciente = _consultasRepository.BuscarIdPaciente(idJti);

                return Ok(_consultasRepository.BuscarPorPaciente(idPaciente));
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

        [Authorize]
        [HttpGet("medico")]
        public IActionResult GetMyM()
        {
            try
            {
                // Converter idUsuario para IdMedico
                int idJti = Convert.ToInt32(HttpContext.User.Claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Jti).Value);
                int idMedico = _consultasRepository.BuscarIdMedico(idJti);

                return Ok(_consultasRepository.BuscarPorMedico(idMedico));
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

        [Authorize(Roles = "2")]
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, string descricao)
        {
            try
            {
                // Faz a chamada para o método
                _consultasRepository.AtualizarDescricao(id, descricao);

                // Retora a resposta da requisição 204 - No Content
                return StatusCode(204);
            }
            catch (Exception error)
            {
                // Retorna a resposta da requisição 400 - Bad Request e o erro ocorrido
                return BadRequest(error);
            }
        }
    }
}
