using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Movilet.Services;
using Movilet.Entities;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Movilet.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PacienteController : ControllerBase
    {
        private readonly PacienteService _pacienteservice;

        public PacienteController(PacienteService pacienteservice)
        {
            _pacienteservice = pacienteservice;
        }
        [HttpGet("all")]
        public ActionResult<List<Paciente>> GetAll()
        {
            return _pacienteservice.GetAll();
        }

        [HttpGet("id")]
        public ActionResult<Paciente> Get([FromQuery] string id)
        {
            return _pacienteservice.GetById(id);
        }

        [HttpPost("")]
        public async Task<ActionResult<Paciente>> CrearUsuario(Paciente paciente)
        {

            Paciente objetousuario = _pacienteservice.CreateUser(paciente);
            return objetousuario;
        }

        [HttpPut("")]
        public async Task<ActionResult<Paciente>> ModificarUsuario(Paciente usuario)
        {
            Paciente usuariobd = new Paciente();
            usuariobd = _pacienteservice.GetById(usuario.id);
            Paciente objetousuario = _pacienteservice.ModifyUser(usuario);
            return objetousuario;
        }
    }
}
