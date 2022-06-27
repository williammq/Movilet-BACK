using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using Movilet.Entities;
using MongoDB.Bson;
using MongoDB.Bson.IO;
using MongoDB.Bson.Serialization.Attributes;
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
        public pedido Registrar(pedido p)
        {
            _pedido.InsertOne(p);
            return p;
        }
    }
}
