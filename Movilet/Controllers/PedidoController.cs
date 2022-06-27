using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Movilet.Services;
using Movilet.Entities;

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
        public async Task<ActionResult<pedido>> Registrar(pedido pedido)
        {

            pedido p = _pedidoservice.Registrar(pedido);
            return p;
        }
    }
}
