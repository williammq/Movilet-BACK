using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace Movilet.Entities
{
    public class Paciente
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string id { get; set; }

        [BsonElement("nombre")]
        public string nombre { get; set; }
        [BsonElement("apellido")]
        public string apellido { get; set; }
        [BsonElement("tipodocumento")]
        public string tipoDocumento { get; set; }
        [BsonElement("numerodocumento")]
        public string numeroDocumento { get; set; }
        [BsonElement("lugarnacimiento")]
        public string lugarNacimiento { get; set; }
        [BsonElement("tiposeguro")]
        public string tipoSeguro { get; set; }
        [BsonElement("fechanacimiento")]
        public DateTime fechaNacimiento { get; set; }
        [BsonElement("sexo")]
        public string sexo { get; set; }
        [BsonElement("telefonosreferencias")]
        public List<Telefonos> telefonosReferencia { get; set; }
        [BsonElement("motivoingreso")]
        public String motivoIngreso { get; set; }
        [BsonElement("fechaingreso")]
        public DateTime fechaIngreso { get; set; }
    }
    public class Telefonos
    {
        public string numero { get; set; }
        public string referentefamiliar { get; set; }
        public string parentesco { get; set; }

    }
}
