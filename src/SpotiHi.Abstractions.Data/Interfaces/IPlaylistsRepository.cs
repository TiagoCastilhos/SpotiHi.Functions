using SpotiHi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SpotiHi.Abstractions.Data.Interfaces
{
    public interface IPlaylistsRepository
    {
        Task<Playlist> GetPlaylistAsync(Guid id);

        Task<IEnumerable<Playlist>> GetAllPlaylistsAsync();

        Task UpdatePlaylistAsync(Guid id, Playlist playlist);

        Task InsertPlaylistAsync(Playlist playlist);

        Task DeletePlaylistAsync(Guid id);
    }
}