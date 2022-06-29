using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using Movilet.Entities;
using MongoDB.Bson;
using MongoDB.Bson.IO;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization;
using System.Text.Json;

namespace Movilet.Services
{
    public class pedidoService
    {
        private readonly IMongoCollection<pedido> _pedido;
        public pedidoService(IMoviletDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _pedido = database.GetCollection<pedido>("pedido");
        }
        public pedido Registrar(string p)
        {
            var pgenerico = JsonSerializer.Deserialize<pedido>(p);
            switch (pgenerico.tipo_servicio)
            {
                case "Talonario": pgenerico = JsonSerializer.Deserialize<pedidoTalonario>(p); break;
                //case "Revista": pgenerico = JsonSerializer.Deserialize<pedidoRevista>(p); break;
                case "Tarjeta de Presentacion": pgenerico = JsonSerializer.Deserialize<pedidoTarjetaPresentacion>(p); break;
                case "Carpeta": pgenerico = JsonSerializer.Deserialize<pedidoCarpeta>(p); break;
                case "Triptico": pgenerico = JsonSerializer.Deserialize<pedidoTriptico>(p); break;
                default:pgenerico= JsonSerializer.Deserialize<pedido>(p); break;
            }
            _pedido.InsertOne(pgenerico);
            return pgenerico;
        }
        public List<object> GetAll()
        {
            //List<pedido> pedidos = new List<pedido>();
            //pedidos = _pedido.AsQueryable().ToList();
            return _pedido.AsQueryable().ToList().Cast<object>().ToList();
        }
        public pedido GetById(string id)
        {
            pedido p = new pedido();
            p = _pedido.Find(x=>x.id==id).FirstOrDefault();
            return p;
        }
    }
}
