using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using MongoDB.Bson;
using MongoDB.Bson.IO;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using JsonReader = Newtonsoft.Json.JsonReader;

namespace Movilet.Entities
{
    public class pedido
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string id { get; set; }
        [BsonElement("nombre_apellidos")]
        public string nombre_apellidos { get; set; }
        [BsonElement("numero_celular")]
        public string numero_celular { get; set; }
        [BsonElement("correo")]
        public string correo { get; set; }
        [BsonElement("fecha_registro")]
        public DateTime fecha_registro { get; set; } = DateTime.Now;
        [BsonElement("estado")]
        public string estado { get; set; }
        [BsonElement("productos")]
        public List<productoPedido> productos { get; set; }
    }

    //[BsonDiscriminator(RootClass = true)]
    [BsonKnownTypes(typeof(Talonario), typeof(TarjetaPresentación), typeof(Triptico))]
    public class productoPedido
    {
        //[BsonId]
        //[BsonRepresentation(BsonType.ObjectId)]
        //public string id { get; set; }
        [BsonElement("id_producto")]
        public string id_producto { get; set; }
        //[BsonElement("id_pedido")]
        //public string id_pedido { get; set; }
        [BsonElement("tipo_impresion")]
        public string tipo_impresion { get; set; }
        [BsonElement("cantidad_ejemplares")]
        public Int32 cantidad_ejemplares { get; set; }
        [BsonElement("tamanio")]
        public string tamanio { get; set; }
        [BsonElement("tipo_hoja")]
        public string tipo_hoja { get; set; }
        [BsonElement("acabado_Hoja")]
        public string acabado_Hoja { get; set; }
        [BsonElement("archivos")]
        public List<string> archivos { get; set; }
    }
    public class Talonario : productoPedido
    {
        public Boolean numerado { get; set; }
        public int copias { get; set; }
        public Boolean orientacion { get; set; }
    }
    public class TarjetaPresentación : productoPedido
    {
        public Boolean plastificado { get; set; }
        public string acabado_plastificado { get; set; }
        public Boolean esquinas { get; set; }
    }
    public class Triptico : productoPedido
    {
        public Boolean plegado { get; set; }
        public string tipo_plegado { get; set; }
        public Boolean orientacion { get; set; }
    }
}
