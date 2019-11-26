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
    public class GetPlaylist
    {
        private readonly IPlaylistsRepository _playlistsRepository;

        public GetPlaylist(IPlaylistsRepository playlistsRepository)
        {
            _playlistsRepository = playlistsRepository ?? throw new ArgumentNullException(nameof(playlistsRepository));
        }

        [FunctionName("GetPlaylist")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "Playlists/{rawPlaylistId}")] HttpRequest req, string rawPlaylistId)
        {
            if (string.IsNullOrEmpty(rawPlaylistId) || !Guid.TryParse(rawPlaylistId, out var playlistId) || playlistId == Guid.Empty)
                return new BadRequestResult();

            var playlist = await _playlistsRepository.GetPlaylistAsync(playlistId);

            return new OkObjectResult(playlist);
        }
    }
}