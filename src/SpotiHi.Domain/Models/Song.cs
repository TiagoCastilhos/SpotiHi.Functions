using System;

namespace SpotiHi.Domain.Models
{
    public class Song
    {
        public string Name { get; set; }
        
        public Artist Artist { get; set; }
    }
}