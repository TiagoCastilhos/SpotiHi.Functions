using Design.Promob.ProjectsApi.Data.Connections;
using MongoDB.Driver;
using SpotiHi.Abstractions.Data.Interfaces;
using SpotiHi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SpotiHi.Data.Repositories
{
    public class PlaylistsRepository : IPlaylistsRepository
    {
        private const string CollectionName = "Playlists";
        private readonly IMongoCollection<Playlist> _collection;

        public PlaylistsRepository(MongoDBConnection connection)
        {
            if (connection == null)
                throw new ArgumentNullException(nameof(connection));

            _collection = connection.GetCollection<Playlist>(CollectionName);
        }

        public async Task<Playlist> GetPlaylistAsync(Guid id)
        {
            if (id == Guid.Empty) throw new ArgumentNullException(nameof(id));

            var filter = Builders<Playlist>.Filter.Eq(p => p.Id, id);

            using (var result = await _collection.FindAsync(filter))
                return await result.FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Playlist>> GetAllPlaylistsAsync()
        {
            var filter = Builders<Playlist>.Filter.Empty;

            var result = await _collection.FindAsync(filter);

            return result.ToEnumerable();
        }

        public async Task UpdatePlaylistAsync(Guid id, Playlist playlist)
        {
            if (id == Guid.Empty) throw new ArgumentNullException(nameof(id));
            if (playlist == null) throw new ArgumentNullException(nameof(playlist));

            var filter = Builders<Playlist>.Filter.Eq(p => p.Id, id);

            await _collection.ReplaceOneAsync(filter, playlist);
        }

        public async Task InsertPlaylistAsync(Playlist playlist)
        {
            if (playlist == null) throw new ArgumentNullException(nameof(playlist));

            await _collection.InsertOneAsync(playlist);
        }

        public async Task DeletePlaylistAsync(Guid id)
        {
            if (id == Guid.Empty) throw new ArgumentNullException(nameof(id));

            var filter = Builders<Playlist>.Filter.Eq(p => p.Id, id);

            await _collection.DeleteOneAsync(filter);
        }        
    }
}