using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using pokemon_tcg_collection_api.Context;
using pokemon_tcg_collection_api.Models;
using pokemon_tcg_collection_api.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pokemon_tcg_collection_api.Services
{
    public class CardService : ICardService
    {
        private readonly IConfiguration _configuration;
        private readonly MyAppContext _context;

        public CardService(IConfiguration configuration, MyAppContext context)
        {
            _configuration = configuration;
            _context = context;
        }

        public async Task<UserCardEntity> InsertUserCardAsync(string externalId, int userId)
        {
            var card = new UserCardEntity { ExternalId = externalId, UserId = userId };

            var cardToInsert = await _context.Cards.AddAsync(card);
            await _context.SaveChangesAsync();

            var insertedCard = await _context.Cards
                .Where(u => u.Id == cardToInsert.Entity.Id)
                .FirstOrDefaultAsync();

            return insertedCard;
        }

        public async Task<IEnumerable<UserCardEntity>> GetUserCardsAsync(int userId)
        {
            var cards = await _context.Cards.Where(x => x.UserId == userId).ToListAsync();
            return cards;
        }
    }
}
