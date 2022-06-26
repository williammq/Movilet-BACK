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
    [BsonDiscriminator(RootClass = true)]
    [BsonKnownTypes(
       typeof(InformeEducativoInicial),
        typeof(InformeSeguimientoEducativo)
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
    public class ContenidoInformeSeguimientoEducativo
    {

        [BsonElement("modalidad")]
        public String modalidad { get; set; }
        [BsonElement("nivel")]
        public String nivel { get; set; }
        [BsonElement("grado")]
        public String grado { get; set; }
        [BsonElement("añoescolar")]
        public String añoEscolar { get; set; }
        [BsonElement("trimestre")]
        public List<Trimestre> trimestre { get; set; }
        //[BsonElement("firmas")]
        //public List<Firmas> firmas { get; set; }
        [BsonElement("codigodocumento")]
        public String codigoDocumento { get; set; }

    }
    public class Trimestre
    {
        public String orden { get; set; }
        public List<Puntajes> puntajes { get; set; }
        public String analisiseducativo { get; set; }
        public String recomendaciones { get; set; }

    }
    public class Puntajes
    {
        public String area { get; set; }
        public String promedio { get; set; }
    }
    public class InformeSeguimientoEducativo : Documento
    {
        public ContenidoInformeSeguimientoEducativo contenido { get; set; } = new ContenidoInformeSeguimientoEducativo();
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
}
    
