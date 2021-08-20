using pokemon_tcg_collection_api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace pokemon_tcg_collection_api.Services.Interfaces
{
    public interface ICardService
    {
        public Task<UserCardEntity> InsertUserCardAsync(string externalId, int userId);
        public Task<IEnumerable<UserCardEntity>> GetUserCardsAsync(int userId);
    }
}