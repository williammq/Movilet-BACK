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
        public async Task<ActionResult<pedido>> Registrar([FromBody] string pedido)
        {
            var pgenerico= JsonSerializer.Deserialize<pedido>(pedido);
            switch (pgenerico.tipo_servicio)
            {
                case "Talonario": pgenerico = JsonSerializer.Deserialize<pedidoTalonario>(pedido); break;
                case "Revista": pgenerico = JsonSerializer.Deserialize<pedidoRevista>(pedido); break;
                case "Tarjeta de Presentacion": pgenerico = JsonSerializer.Deserialize<pedidoTarjetaPresentacion>(pedido); break;
                case "Carpeta": pgenerico = JsonSerializer.Deserialize<pedidoCarpeta>(pedido); break;
                case "Triptico": pgenerico = JsonSerializer.Deserialize<pedidoTriptico>(pedido); break;
                default:pgenerico= JsonSerializer.Deserialize<pedido>(pedido); break;
            }
            pedido p = _pedidoservice.Registrar(pgenerico);
            return p;
        }
    }
}
