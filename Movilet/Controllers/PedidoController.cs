using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Movilet.Services;
using Movilet.Entities;
using System.Text.Json;

namespace Movilet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private readonly pedidoService _pedidoservice;

        public PedidoController(pedidoService pedidoservice)
        {
            _pedidoservice = pedidoservice;
        }
        [HttpPost("Registrar")]
        public async Task<IActionResult> Registrar([FromBody] string pedido)
        {
            var p = _pedidoservice.Registrar(pedido);
            return Ok(p);
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var lst = _pedidoservice.GetAll();
            return Ok(lst);
        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(string id)
        {
            var result = _pedidoservice.GetById(id);
            return Ok(result);
        }
    }
}
