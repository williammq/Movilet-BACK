﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Movilet.DTOs
{
    public class SeguimientoDTO
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string id { get; set; }
        public string tipo { get; set; }
        public DateTime? fechacreacion { get; set; }
        public string estado { get; set; }
        public string codigodocumento { get; set; }
        public string nombrecompleto { get; set; }

    }
}
