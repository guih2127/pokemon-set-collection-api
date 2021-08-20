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

        public async Task<IEnumerable<string>> InsertUserCardAsync(string externalId, int userId)
        {
            var card = new UserCardEntity { ExternalId = externalId, UserId = userId };

            await _context.Cards.AddAsync(card);
            await _context.SaveChangesAsync();

            var cards = await _context.Cards.Where(x => x.UserId == userId).Select(x => x.ExternalId).ToListAsync();
            return cards;
        }

        public async Task<IEnumerable<string>> RemoveUserCardAsync(string externalId, int userId)
        {
            var card = await _context.Cards.Where(x => x.ExternalId == externalId && x.UserId == userId).FirstOrDefaultAsync();
            _context.Cards.Remove(card);
            await _context.SaveChangesAsync();

            var cards = await _context.Cards.Where(x => x.UserId == userId).Select(x => x.ExternalId).ToListAsync();
            return cards;
        }

        public async Task<IEnumerable<string>> GetUserCardsAsync(int userId)
        {
            var cards = await _context.Cards.Where(x => x.UserId == userId).Select(x => x.ExternalId).ToListAsync();
            return cards;
        }
    }
}
