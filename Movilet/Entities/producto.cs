using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.IO;
using MongoDB.Bson.Serialization.Attributes;
namespace Movilet.Entities
{
    public class producto
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string id { get; set; }
        [BsonElement("nombre")]
        public string nombre { get; set; }
        [BsonElement("tamanios")]
        public List<string> tamanios { get; set; }
        [BsonElement("tipos_hoja")]
        public List<string> tipos_hoja { get; set; }
        [BsonElement("url_imagen")]
        public string url_imagen { get; set; }
    }
}
