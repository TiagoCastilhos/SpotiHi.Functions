namespace SpotiHi.Dtos.Requests
{
    public class SongRequest
    {
        public string Name { get; set; }

        public ArtistRequest Artist { get; set; }
    }
}