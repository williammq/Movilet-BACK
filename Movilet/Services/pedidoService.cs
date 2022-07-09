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
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting.Internal;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json.Linq;

namespace Movilet.Services
{
    public class pedidoService
    {
        private readonly IMongoCollection<pedido> _pedidos;
        private readonly IMongoCollection<producto> _producto;
        private readonly IHostingEnvironment _enviroment;
        private readonly string contentPath="";
        public pedidoService(IMoviletDatabaseSettings settings, IHostingEnvironment env)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _pedidos = database.GetCollection<pedido>("pedido");
            _producto = database.GetCollection<producto>("producto");
            _enviroment = env;
            contentPath = _enviroment.ContentRootPath;
        }
        public pedido Registrar(string p)
        {
            var lst = JObject.Parse(p)["productos"].ToObject<List<object>>();
            List<ProductoRequisitos> productos = new List<ProductoRequisitos>();
            foreach (JObject itemjs in lst)
            {
                string idProducto = itemjs["id_producto"].Value<string>();
                switch (idProducto)
                {
                    case "62c269314a16a2fae57841c9":
                        productos.Add(itemjs.ToObject<Talonario>());
                        break;
                    case "62c268d94a16a2fae57841c8": 
                        productos.Add(itemjs.ToObject<TarjetaPresentación>());
                        break;
                    case "62c266644a16a2fae57841c4": 
                        productos.Add(itemjs.ToObject<Triptico>());
                        break;
                    default:
                        productos.Add(itemjs.ToObject<ProductoRequisitos>());
                        break;
                }
            }
            pedido pgenerico = JsonSerializer.Deserialize<pedido>(p);
            pgenerico.productos = productos;
            _pedidos.InsertOne(pgenerico);
            return pgenerico;
        }
        public string GetPath(string base64)
        {
            byte[] arrayBytes = Convert.FromBase64String(base64);
            string id = Guid.NewGuid().ToString();
            string ruta = System.IO.Path.Combine(contentPath,"images", id + ".png");
            System.IO.File.WriteAllBytes(ruta,arrayBytes);
            return ruta;
        }
        public List<pedido> GetAll()
        {
            //List<pedido> pedidos = new List<pedido>();
            //pedidos = _pedido.AsQueryable().ToList();
            return _pedidos.AsQueryable().ToList().Cast<pedido>().ToList();
        }
        public pedido GetById(string id)
        {
            pedido p = new pedido();
            p = _pedidos.Find(x=>x.id==id).FirstOrDefault();
            return p;
        }
        public List<producto> GetAllProducto()
        {
            return _producto.Find(x => true).ToList();
        }
    }
}
