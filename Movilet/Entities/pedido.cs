using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.IO;
using MongoDB.Bson.Serialization.Attributes;

namespace Movilet.Entities
{
    [BsonDiscriminator(RootClass = true)]
    [BsonKnownTypes(typeof(pedidoTalonario),
                    typeof(pedidoTarjetaPresentacion),
                    typeof(pedidoCarta),
                    typeof(pedidoTriptico))]
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
        [BsonElement("producto")]
        public string producto { get; set; }
        [BsonElement("tipo_impresion")]
        public string tipo_impresion { get; set; }
        [BsonElement("cantidad_ejemplares")]
        public int cantidad_ejemplares { get; set; }
        [BsonElement("tamanio_hoja")]
        public string tamanio_hoja { get; set; }
        [BsonElement("estado")]
        public string estado { get; set; }
        [BsonElement("tipo_hoja")]
        public string tipo_hoja { get; set; }
        [BsonElement("archivos")]
        public List<string> archivos { get; set; }
    }
    public class talonario 
    {
        public string microperforado { get; set; }
        public Boolean numerado { get; set; }
        public string tipo_encuadernado { get; set; }
    }
    public class pedidoTalonario : pedido
    {
        public talonario requisitos { get; set; }
    }
    public class tarjetaPresentacion
    {
        public Boolean plegado { get; set; }
        public Boolean esquinas { get; set; }
    }
    public class pedidoTarjetaPresentacion: pedido
    {
        public tarjetaPresentacion requisitos { get; set; }
    }
    public class triptico
    {
        public Boolean plegado { get; set; }
        public string tipo_plegado { get; set; }
    }
    public class pedidoTriptico : pedido
    {
        public triptico requisitos { get; set; }
    }
    public class carta_comida
    {
        public Boolean plegado { get; set; }
        public string tipo_plegado { get; set; }
    }
    public class pedidoCarta : pedido
    {
        public carta_comida requisitos { get; set; }
    }
}
