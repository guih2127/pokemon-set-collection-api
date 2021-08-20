using System.Text.Json.Serialization;

namespace pokemon_tcg_collection_api.Models
{
    public class UserCardEntity
    {
        public int Id { get; set; }
        public string ExternalId { get; set; }
        public int UserId { get; set; }

        [JsonIgnore]
        public UserEntity User { get; set; }
    }
}
