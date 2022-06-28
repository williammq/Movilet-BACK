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
                    typeof(pedidoRevista),
                    typeof(pedidoCarpeta),
                    typeof(pedidoTarjetaPresentacion),
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
        [BsonElement("tipo_servicio")]
        public string tipo_servicio { get; set; }
        [BsonElement("tipo_impresion")]
        public string tipo_impresion { get; set; }
        [BsonElement("cantidad_ejemplares")]
        public int cantidad_ejemplares { get; set; }
        [BsonElement("tamanio_hoja")]
        public string tamanio_hoja { get; set; }
    }
    public class talonario 
    {
        public string microperforado { get; set; }
        public Boolean numerado { get; set; }
        public string tipo_encuadernado { get; set; }
    }
    public class pedidoTalonario : pedido
    {
        public talonario requisitos { get; set; } = new talonario();
    }
    public class revista
    {
        public int numero_paginas { get; set; }
        public Boolean portada_plastificada { get; set; }
        public string tipo_hoja_portada { get; set; }
        public string tipo_hoja_paginas { get; set; }
    }
    public class pedidoRevista : pedido
    {
        public revista requisitos { get; set; } = new revista();
    }
    public class tarjetaPresentacion
    {
        public string tipo_hoja { get; set; }
        public Boolean plastificado { get; set; }
        public Boolean esquinas { get; set; }
    }
    public class pedidoTarjetaPresentacion: pedido
    {
        public tarjetaPresentacion requisitos { get; set; } = new tarjetaPresentacion();
    }
    public class carpeta
    {
        public Boolean plastificado { get; set; }
        public string tipo_hoja { get; set; }
    }
    public class pedidoCarpeta : pedido
    {
        public carpeta requisitos { get; set; } = new carpeta();
    }
    public class triptico
    {
        public Boolean plegado { get; set; }
        public string tipo_plegado { get; set; }
        public string tipo_hoja { get; set; }
    }
    public class pedidoTriptico : pedido
    {
        public triptico requisitos { get; set; } = new triptico();
    }
}
