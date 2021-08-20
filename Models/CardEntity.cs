using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace pokemon_tcg_collection_api.Models
{
    public class CardEntity
    {
        public int Id { get; set; }
        public string ExternalId { get; set; }

        [JsonIgnore]
        public List<UserEntity> Users { get; set; }
    }
}
