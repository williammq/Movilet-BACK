using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Movilet.Services;
using Movilet.Entities;
using System.Text.Json;
using Microsoft.AspNetCore.Http;

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
        public async Task<IActionResult> Registrar(JsonElement json)
        {
            var p = _pedidoservice.Registrar(json.ToString());
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
        [HttpGet("GetAllProducto")]
        public async Task<IActionResult> GetAllProducto()
        {
            var lst = _pedidoservice.GetAllProducto();
            return Ok(lst);
        }
    }
}
