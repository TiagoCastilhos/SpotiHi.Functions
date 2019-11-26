using SpotiHi.Domain.Models;
using System;
using System.Threading.Tasks;

namespace SpotiHi.Abstractions.Core.Interfaces.Services
{
    public interface IPlaylistsService
    {
        Task InsertPlaylistAsync(Playlist playlist);

        Task UpdatePlaylistAsync(Guid id, Playlist playlist);
    }
}