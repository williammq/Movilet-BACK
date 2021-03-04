using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.IO;
using MongoDB.Bson.Serialization.Attributes;
using Movilet.Services;



namespace Movilet.Entities
{
    [BsonDiscriminator(RootClass =true)]
    [BsonKnownTypes(
       typeof(InformeEducativoInicial)
        )]
    public class Documento
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string id { get; set; }
        [BsonElement("tipo")]
        public string tipo { get; set; }
        [BsonElement("historialcontenido")]
        public List<HistorialContenido> historialcontenido { get; set; }
        [BsonElement("creadordocumento")]
        public string creadordocumento { get; set; }
        [BsonElement("fechacreacion")]
        public DateTime? fechacreacion { get; set; }
        [BsonElement("area")]
        public string area { get; set; }
        [BsonElement("fase")]
        public string fase { get; set; }
        [BsonElement("idresidente")]
        public string idresidente { get; set; }
        [BsonElement("estado")]
        public string estado { get; set; }
    }
    public class ContenidoInformeEducativoInicial
    {
        public string situacionacademica { get; set; }
        public string analisisacademico { get; set; }
        public List<string> conclusiones { get; set; }
        public List<AnexosDocumento> anexos { get; set; }
        public string codigodocumento { get; set; }
        public string lugarevaluacion { get; set; }
    }

    public class InformeEducativoInicial : Documento
    {
        public ContenidoInformeEducativoInicial contenido { get; set; } = new ContenidoInformeEducativoInicial();
    }
    public class HistorialContenido
    {
        public int version { get; set; }
        public DateTime fechamodificacion { get; set; }
        public string url { get; set; }
    }
    public class AnexosDocumento
    {
        public string url { get; set; }
        public string titulo { get; set; }
    }
    public class ContenidoInformePrueba
    {



    }
}   
