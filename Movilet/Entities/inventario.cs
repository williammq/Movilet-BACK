using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movilet.Entities
{
    public class inventario
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string id { get; set; }
        [BsonElement("insumo")]
        public datosInsumo insumo { get; set; }
        [BsonElement("unidad")]
        public string unidad { get; set; }
        [BsonElement("categoria")]
        public string categoria { get; set; }
        [BsonElement("stock_disponible")]
        public Int32 stock_disponible { get; set; }
        [BsonElement("fecha_compra")]
        public DateTime fecha_compra { get; set; }
        [BsonElement("costo_unitario")]
        public double costo_unitario { get; set; }
    }
    public class datosInsumo
    {
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public string unidad_insumo { get; set; }
        public double cantidad_insumo { get; set; }
        public double costo_insumo { get; set; }
    }
}
