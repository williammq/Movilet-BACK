using MongoDB.Bson;
using MongoDB.Driver;
using Movilet.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movilet.Services
{
    public class PacienteService
    {
        private readonly IMongoCollection<Paciente> _paciente;
        public PacienteService(IMoviletDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _paciente = database.GetCollection<Paciente>("paciente");

        }
    public List<Paciente> GetAll()
    {
        List<Paciente> pacientes = new List<Paciente>();
        pacientes = _paciente.Find(Paciente => true).ToList();
        return pacientes;
    }
        public Paciente GetById(string id)
        {
            Paciente paciente = new Paciente();
            paciente = _paciente.Find(paciente => paciente.id == id).FirstOrDefault();
            return paciente;
        }
        public Paciente CreateUser(Paciente paciente)
        {
            _paciente.InsertOne(paciente);
            return paciente;

        }
        public Paciente ModifyUser(Paciente paciente)
        {
            var filter = Builders<Paciente>.Filter.Eq("id", paciente.id);
            var update = Builders<Paciente>.Update
                .Set("nombre", paciente.nombre)
                .Set("apellido", paciente.apellido)
                .Set("tipodocumento", paciente.tipoDocumento)
                .Set("numerodocumento", paciente.numeroDocumento)
                .Set("lugarnacimiento", paciente.lugarNacimiento)
                .Set("tiposeguro", paciente.tipoSeguro)
                .Set("fechanacimiento", paciente.fechaNacimiento)
                .Set("sexo", paciente.sexo)
                .Set("telefonosreferencias", paciente.telefonosReferencia)
                .Set("motivoingreso", paciente.motivoIngreso)
                .Set("fechaingreso", paciente.fechaIngreso);
                
            paciente = _paciente.FindOneAndUpdate<Paciente>(filter, update, new FindOneAndUpdateOptions<Paciente>
            {
                ReturnDocument = ReturnDocument.After
            });
            return paciente;
        }



    }
}
