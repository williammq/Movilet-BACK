using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movilet.Entities
{
    public class cotizacion
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string id { get; set; }
        [BsonElement("codigo")]
        public string codigo { get; set; }
        [BsonElement("codigo")]
        public DateTime fecha_entrega { get; set; }
        [BsonElement("productos")]
        List<productoCotizado> productos { get; set; } 
    }
    public class productoCotizado
    {
        public string id_producto { get; set; }
        public double mano_obra_unitario { get; set; }
        public double costo_total_elaboracion { get; set; }
        public List<insumoCotizado> insumos_cotizados { get; set; }
    }
    public class insumoCotizado
    {
        public string id_insumo { get; set; }
        public int cantidad_requerida { get; set; }
    }
}
