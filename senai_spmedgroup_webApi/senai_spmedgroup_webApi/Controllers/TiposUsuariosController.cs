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
    public class TiposUsuariosController : ControllerBase
    {
        private ITipoUsuarioRepository _tiposRepository { get; set; }

        public TiposUsuariosController()
        {
            _tiposRepository = new TipoUsuarioRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_tiposRepository.Listar());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_tiposRepository.BuscarPorId(id));
        }

        [HttpPost]
        public IActionResult Post(TiposUsuario novoTipo)
        {
            _tiposRepository.Cadastrar(novoTipo);

            return StatusCode(201);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, TiposUsuario tipoAtualizado)
        {
            _tiposRepository.Atualizar(id, tipoAtualizado);

            return StatusCode(204);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _tiposRepository.Deletar(id);

            return StatusCode(204);
        }
    }
}
