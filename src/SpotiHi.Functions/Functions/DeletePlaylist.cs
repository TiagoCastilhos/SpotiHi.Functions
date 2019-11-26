using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SpotiHi.Abstractions.Data.Interfaces;

namespace SpotiHi.Functions.Functions
{
    public class DeletePlaylist
    {
        private readonly IPlaylistsRepository _playlistsRepository;

        public DeletePlaylist(IPlaylistsRepository playlistsRepository)
        {
            _playlistsRepository = playlistsRepository ?? throw new ArgumentNullException(nameof(playlistsRepository));
        }

        [FunctionName("DeletePlaylist")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "delete", Route = "Playlists/{rawPlaylistId}")] HttpRequest req, string rawPlaylistId)
        {
            if (string.IsNullOrEmpty(rawPlaylistId) || !Guid.TryParse(rawPlaylistId, out var playlistId) || playlistId == Guid.Empty)
                return new BadRequestResult();

            await _playlistsRepository.DeletePlaylistAsync(playlistId);

            return new OkResult();
        }
    }
}