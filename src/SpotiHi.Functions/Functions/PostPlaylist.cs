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
    public class PostPlaylist
    {
        private readonly IPlaylistsService _playlistsService;

        public PostPlaylist(IPlaylistsService playlistsService)
        {
            _playlistsService = playlistsService ?? throw new ArgumentNullException(nameof(playlistsService));
        }

        [FunctionName("PostPlaylist")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "Playlists")] HttpRequest req)
        {
            var stringContent = await req.ReadAsStringAsync();

            if (string.IsNullOrEmpty(stringContent)) return new BadRequestResult();

            var playlist = JsonConvert.DeserializeObject<Playlist>(stringContent);

            if (playlist == null) return new BadRequestResult();

            await _playlistsService.InsertPlaylistAsync(playlist);

            return new OkObjectResult(playlist.Id);
        }
    }
}