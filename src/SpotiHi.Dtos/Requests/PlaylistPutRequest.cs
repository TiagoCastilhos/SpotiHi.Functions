using System.Collections.Generic;

namespace SpotiHi.Dtos.Requests
{
    public class PlaylistPutRequest
    {
        public IEnumerable<SongRequest> Songs { get; set; }

        public string Name { get; set; }
    }
}