using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Movilet.Services;
using Movilet.Entities;



namespace Movilet.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioService _usuarioservice;

        public UsuarioController(UsuarioService usuarioservice)
        {
            _usuarioservice = usuarioservice;
        }
        [HttpGet("all")]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public ActionResult<List<Usuario>> GetAll()
        {
            return _usuarioservice.GetAll();
        }

        [HttpGet("id")]
        public ActionResult<Usuario> Get([FromQuery] string id)
        {
            return _usuarioservice.GetById(id);
        }

        [HttpPost("")]
        public async Task<ActionResult<Usuario>> CrearUsuario(Usuario usuario)
        {
            
            Usuario objetousuario = _usuarioservice.CreateUser(usuario);
            return objetousuario;
        }

        [HttpPut("")]
        public async Task<ActionResult<Usuario>> ModificarUsuario([FromQuery] string tipo, [FromQuery] string tipoFirma, Usuario usuario)
        {
            Usuario usuariobd = new Usuario();
            usuariobd = _usuarioservice.GetById(usuario.id);
            Usuario objetousuario = _usuarioservice.ModifyUser(usuario);
            return objetousuario;
        }
    }

}
