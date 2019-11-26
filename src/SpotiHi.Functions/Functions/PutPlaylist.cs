using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Newtonsoft.Json;
using SpotiHi.Abstractions.Core.Interfaces.Services;
using SpotiHi.Domain.Models;
using System;
using System.Threading.Tasks;

namespace SpotiHi.Functions.Functions
{
    public class PutPlaylist
    {
        private readonly IPlaylistsService _playlistsService;

        public PutPlaylist(IPlaylistsService playlistsService)
        {
            _playlistsService = playlistsService ?? throw new ArgumentNullException(nameof(playlistsService));
        }

        [FunctionName("PutPlaylist")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "put", Route = "Playlists/{rawPlaylistId}")] HttpRequest req, string rawPlaylistId)
        {
            if (string.IsNullOrEmpty(rawPlaylistId) || !Guid.TryParse(rawPlaylistId, out var playlistId) || playlistId == Guid.Empty)
                return new BadRequestResult();

            var stringContent = await req.ReadAsStringAsync();

            if (string.IsNullOrEmpty(stringContent)) return new BadRequestResult();

            var playlist = JsonConvert.DeserializeObject<Playlist>(stringContent);

            if (playlist == null) return new BadRequestResult();

            await _playlistsService.UpdatePlaylistAsync(playlistId, playlist);

            return new OkResult();
        }
    }
}