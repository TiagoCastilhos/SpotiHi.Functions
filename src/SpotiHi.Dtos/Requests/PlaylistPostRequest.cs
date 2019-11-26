using System;
using System.Collections.Generic;
using System.Text;

namespace SpotiHi.Dtos.Requests
{
    public class PlaylistPostRequest
    {
        public IEnumerable<SongRequest> Songs { get; set; }

        public string Name { get; set; }
    }
}