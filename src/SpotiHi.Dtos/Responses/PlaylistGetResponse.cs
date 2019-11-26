using System;
using System.Collections.Generic;
using System.Text;

namespace SpotiHi.Dtos.Responses
{
    public class PlaylistGetResponse
    {
        public Guid Id { get; set; }

        public IEnumerable<SongGetResponse> Songs { get; set; }

        public string Name { get; set; }

        public DateTime CreationDate { get; set; }
    }
}