using System;
using System.Collections.Generic;
using System.Text;

namespace SpotiHi.Dtos.Responses
{
    public class SongGetResponse
    {
        public string Name { get; set; }

        public ArtistGetResponse Artist { get; set; }
    }
}