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
        [BsonElement("id_pedido")]
        public string id_pedido { get; set; }
        [BsonElement("fecha_entrega")]
        public DateTime fecha_entrega { get; set; }
        [BsonElement("productosCotizados")]
        public List<productoCotizado> productos_cotizados { get; set; } 
    }
    public class productoCotizado
    {
        public string id_producto { get; set; }
        public double mano_obra_unitario { get; set; }
        public double costo_elaboracion_unitaria { get; set; }
        public int cantidad_ejemplares_solicitado { get; set; }
        public List<insumoCotizado> insumos_cotizados { get; set; }
    }
    public class insumoCotizado
    {
        public string id_insumo { get; set; }
        public string nombre { get; set; }
        public string unidad_insumo { get; set; }
        public double cantidad_requerida { get; set; }
        public double costo_unitario_insumo { get; set; }
    }
}
