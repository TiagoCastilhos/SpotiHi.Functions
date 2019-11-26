using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using SpotiHi.Abstractions.Data.Interfaces;
using System.Threading.Tasks;

namespace SpotiHi.Functions.Functions
{
    public class GetAllPlaylists
    {
        private readonly IPlaylistsRepository _playlistsRepository;

        public GetAllPlaylists(IPlaylistsRepository playlistsRepository)
        {
            _playlistsRepository = playlistsRepository;
        }

        [FunctionName("GetAllPlaylists")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "Playlists")] HttpRequest req)
        {
            var playlists = await _playlistsRepository.GetAllPlaylistsAsync();

            return new OkObjectResult(playlists);
        }
    }
}