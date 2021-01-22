using MongoDB.Bson;
using MongoDB.Driver;
using Movilet.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movilet.Services
{
    public class UsuarioService
    {
        private readonly IMongoCollection<Usuario> _usuarios;
    
        public UsuarioService(IMoviletDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _usuarios = database.GetCollection<Usuario>("usuario");
           
        }

        public List<Usuario> GetAll()
        {
            List<Usuario> usuarios = new List<Usuario>();
            usuarios = _usuarios.Find(Usuario => true).ToList();
            return usuarios;
        }
        public Usuario GetById(string id)
        {
            Usuario usuario = new Usuario();
            usuario = _usuarios.Find(usuario => usuario.id == id).FirstOrDefault();
            return usuario;
        }

        public Usuario GetByUserNameAndPass(string username, string pass)
        {
            Usuario usuario = new Usuario();
            usuario = _usuarios.Find(usuario => usuario.usuario == username & usuario.clave == pass).FirstOrDefault();
            return usuario;
        }
        public Usuario GetByUserName(string username)
        {
            Usuario usuario = new Usuario();
            usuario = _usuarios.Find(usuario => usuario.usuario == username).FirstOrDefault();
            return usuario;
        }

        public Usuario CreateUser(Usuario usuario)
        {
            _usuarios.InsertOne(usuario);
            return usuario;
        }

        public Usuario ModifyUser(Usuario usuario)
        {
            var filter = Builders<Usuario>.Filter.Eq("id", usuario.id);
            var update = Builders<Usuario>.Update
                .Set("usuario", usuario.usuario)
                .Set("clave", usuario.clave)
                .Set("datos", usuario.datos)
                .Set("rol", usuario.rol);
            usuario = _usuarios.FindOneAndUpdate<Usuario>(filter, update, new FindOneAndUpdateOptions<Usuario>
            {
                ReturnDocument = ReturnDocument.After
            });
            return usuario;
        }

    }
}
