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
        private readonly IMongoCollection<BsonDocument> _pedidosBSON;
        private readonly IMongoCollection<producto> _producto;
        private readonly IMongoCollection<productoPedido> _productoPedido;
        private readonly IHostingEnvironment _enviroment;
        private readonly string contentPath = "";
        public pedidoService(IMoviletDatabaseSettings settings, IHostingEnvironment env)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _pedidos = database.GetCollection<pedido>("pedido");
            _pedidosBSON = database.GetCollection<BsonDocument>("pedido");
            _producto = database.GetCollection<producto>("producto");
            _productoPedido = database.GetCollection<productoPedido>("productoPedido");
            _enviroment = env;
            contentPath = _enviroment.ContentRootPath;
        }
        public pedido Registrar(string p)
        {
            //ObjectId idPedido = ObjectId.GenerateNewId();
            pedido pgenerico = new pedido();
            var lst = JObject.Parse(p)["productos"].ToObject<List<object>>();
            List<productoPedido> productos = new List<productoPedido>();
            //List<string> productosID = new List<string>();
            foreach (JObject itemjs in lst)
            {
                string idProducto = itemjs["id_producto"].Value<string>();
                //ObjectId idProductoPedido = ObjectId.GenerateNewId();
                switch (idProducto)
                {
                    case "62c269314a16a2fae57841c9":
                        Talonario t = new Talonario();
                        t = itemjs.ToObject<Talonario>();
                        //t.id = idProductoPedido.ToString();
                        //t.id_pedido = idPedido.ToString();
                        productos.Add(t);
                        //productosID.Add(idProducto);
                        break;
                    case "62c268d94a16a2fae57841c8":
                        TarjetaPresentación tp = new TarjetaPresentación();
                        tp = itemjs.ToObject<TarjetaPresentación>();
                        //tp.id = idProductoPedido.ToString();
                        //tp.id_pedido = idPedido.ToString();
                        productos.Add(tp);
                        //productosID.Add(idProducto);
                        break;
                    case "62c266644a16a2fae57841c4":
                        Triptico tri = new Triptico();
                        tri = itemjs.ToObject<Triptico>();
                        //tri.id = idProductoPedido.ToString();
                        //tri.id_pedido = idPedido.ToString();
                        productos.Add(tri);
                        //productosID.Add(idProducto);
                        break;
                    default:
                        productoPedido pp = new productoPedido();
                        pp = itemjs.ToObject<productoPedido>();
                        //pp.id = idProductoPedido.ToString();
                        //pp.id_pedido = idPedido.ToString();
                        productos.Add(pp);
                        //productosID.Add(idProducto);
                        break;
                }
            }
            //pedido pgenerico = JsonSerializer.Deserialize<pedido>(p);
            //pgenerico.id = idPedido.ToString();
            //pgenerico.estado = "pendiente";
            //pgenerico.nombre_apellidos = JObject.Parse(p)["nombre_apellidos"].ToString();
            //pgenerico.correo = JObject.Parse(p)["correo"].ToString();
            //pgenerico.numero_celular = JObject.Parse(p)["numero_celular"].ToString();
            //productos.ForEach(p => _productoPedido.InsertOne(p));
            //pgenerico.productos = productosID;
            pgenerico = JsonSerializer.Deserialize<pedido>(p);
            pgenerico.productos = productos;
            _pedidos.InsertOne(pgenerico);
            return pgenerico;
        }
        public string GetPath(string base64)
        {
            byte[] arrayBytes = Convert.FromBase64String(base64);
            string id = Guid.NewGuid().ToString();
            string ruta = System.IO.Path.Combine(contentPath, "images", id + ".png");
            System.IO.File.WriteAllBytes(ruta, arrayBytes);
            return ruta;
        }
        public List<object> GetAll()
        {
            List<pedido> pedidosClass = new List<pedido>();
            //List<pedido> pedidosClass = new List<pedido>();
            //List<BsonDocument> pedidosBSON = new List<BsonDocument>();
            //pedidosBSON = _pedidosBSON.Find(x => true).ToList();
            //foreach (BsonDocument item in pedidosBSON)
            //{
            //    List<productoPedido> productos = new List<productoPedido>();
            //    pedido pedido = BsonSerializer.Deserialize<pedido>(item);
            //    var lst = item["productos"].AsBsonArray.Values;
            //    foreach (BsonDocument p in lst)
            //    {
            //        string idproducto = p["id_producto"].AsString;
            //        switch (idproducto)
            //        {
            //            case "62c269314a16a2fae57841c9":
            //                BsonClassMap.LookupClassMap(typeof(Talonario));                          
            //                productos.Add(BsonSerializer.Deserialize<Talonario>(p));
            //                break;
            //            case "62c268d94a16a2fae57841c8":
            //                BsonClassMap.LookupClassMap(typeof(TarjetaPresentación));                
            //                productos.Add(BsonSerializer.Deserialize<TarjetaPresentación>(p));
            //                break;
            //            case "62c266644a16a2fae57841c4":
            //                BsonClassMap.LookupClassMap(typeof(Triptico));
            //                productos.Add(BsonSerializer.Deserialize<Triptico>(p));
            //                break;
            //            default:
            //                productos.Add(BsonSerializer.Deserialize<productoPedido>(p));
            //                break;
            //        }
            //    }
            //    pedido.productos = productos;
            //    pedidosClass.Add(pedido);
            //}
            
            //return _pedidos.AsQueryable().ToList().Cast<object>().ToList();
            return _pedidos.AsQueryable().ToList().Cast<object>().ToList().Cast<object>().ToList();
        }
        public object GetById(string id)
        {
            object lp = new object();
            lp = _pedidos.AsQueryable().ToList().Where(x=>x.id==id).Cast<object>().FirstOrDefault();
            return lp;
        }
        public List<object> GetProductosByIdPedido(string id)
        {
            pedido p = new pedido();
            List<object> productos = new List<object>();
            p = _pedidos.AsQueryable().ToList().Where(x => x.id == id).FirstOrDefault();
            productos.AddRange(p.productos.AsQueryable().ToList().Cast<object>().ToList());
            return productos;
        }
        public List<producto> GetAllProducto()
        {
            return _producto.Find(x => true).ToList();
        }
    }
}
