using ApiAWSPersonajes.Data;
using ApiAWSPersonajes.Models;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Bcpg;

namespace ApiAWSPersonajes.Repositories
{
    public class RepositoryTelevision
    {
        private readonly TelevisionContext context;

        public RepositoryTelevision(TelevisionContext context)
        {
            this.context = context;
        }


        public async Task<List<Personaje>> GetPersonajesAsync()
        {
            return await this.context.Personajes.ToListAsync();
        }

        public async Task<int> GetMaxIdPersonajeAsync()
        {
            return await this.context.Personajes.MaxAsync(p => p.IdPersonaje);
        }

        public async Task InsertPersonajeAsync(int idPersonaje, string nombre, string imagen)
        {
            Personaje personaje = new Personaje
            {
                IdPersonaje = idPersonaje,
                Nombre = nombre,
                Imagen = imagen
            };
            await this.context.Personajes.AddAsync(personaje);
            await this.context.SaveChangesAsync();
        }
    }
}
