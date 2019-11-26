using System;
using System.Collections.Generic;

namespace SpotiHi.Domain.Models
{
    public class Playlist
    {
        public Guid Id { get; set; }

        public IEnumerable<Song> Songs { get; set; }

        public string Name { get; set; }

        public DateTime CreationDate { get; set; }
    }
}