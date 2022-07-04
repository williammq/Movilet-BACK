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
        private readonly IMongoCollection<producto> _producto;
        public pedidoService(IMoviletDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _pedido = database.GetCollection<pedido>("pedido");
            _producto = database.GetCollection<producto>("producto");
        }
        public pedido Registrar(string p)
        {
            var pgenerico = JsonSerializer.Deserialize<pedido>(p);
            switch (pgenerico.producto)
            {
                case "62c269314a16a2fae57841c9": pgenerico = JsonSerializer.Deserialize<pedidoTalonario>(p); break;
                case "62c268964a16a2fae57841c7": pgenerico = JsonSerializer.Deserialize<pedidoCarta>(p); break;
                case "62c268d94a16a2fae57841c8": pgenerico = JsonSerializer.Deserialize<pedidoTarjetaPresentacion>(p); break;
                case "62c266644a16a2fae57841c4": pgenerico = JsonSerializer.Deserialize<pedidoTriptico>(p); break;
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
        public List<producto> GetAllProducto()
        {
            return _producto.Find(x => true).ToList();
        }
    }
}
