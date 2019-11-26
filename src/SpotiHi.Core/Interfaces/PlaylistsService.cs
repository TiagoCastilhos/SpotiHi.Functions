using SpotiHi.Abstractions.Core.Interfaces.Services;
using SpotiHi.Abstractions.Data.Interfaces;
using SpotiHi.Domain.Models;
using System;
using System.Threading.Tasks;

namespace SpotiHi.Core.Interfaces
{
    public class PlaylistsService : IPlaylistsService
    {
        private readonly IPlaylistsRepository _playlistsRepository;

        public PlaylistsService(IPlaylistsRepository playlistsRepository)
        {
            _playlistsRepository = playlistsRepository ?? throw new ArgumentNullException(nameof(playlistsRepository));
        }

        public async Task InsertPlaylistAsync(Playlist playlist)
        {
            if (playlist == null)
                throw new ArgumentNullException(nameof(playlist));

            playlist.Id = Guid.NewGuid();
            playlist.CreationDate = DateTime.UtcNow;

            await _playlistsRepository.InsertPlaylistAsync(playlist);
        }

        public async Task UpdatePlaylistAsync(Guid id, Playlist playlist)
        {
            if (id == Guid.Empty)
                throw new ArgumentNullException(nameof(playlist));

            if (playlist == null)
                throw new ArgumentNullException(nameof(playlist));

            if (id != playlist.Id)
                throw new ArgumentException("id and playlist.Id must be equal");

            await _playlistsRepository.UpdatePlaylistAsync(id, playlist);
        }
    }
}