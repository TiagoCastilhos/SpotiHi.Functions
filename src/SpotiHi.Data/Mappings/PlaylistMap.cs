using MongoDB.Bson.Serialization;
using SpotiHi.Domain.Models;

namespace Design.Promob.ProjectsApi.Data.Mappings
{
    public class PlaylistMap
    {
        public static void Configure()
        {
            BsonClassMap.RegisterClassMap<Playlist>(map =>
            {
                map.AutoMap();
                map.SetIgnoreExtraElements(true);
                map.MapMember(p => p.Id).SetIsRequired(true);
                map.SetIdMember(map.GetMemberMap(p => p.Id));
            });
        }
    }
}