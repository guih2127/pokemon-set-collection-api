using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace pokemon_tcg_collection_api.Models
{
    public class UserEntity
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }

        [JsonIgnore]
        public List<UserCardEntity> CardsObtained { get; set; }
    }
}
