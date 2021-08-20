using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using pokemon_tcg_collection_api.Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace pokemon_tcg_collection_api.Controllers
{
    public class CardsController : ControllerBase
    {
        private readonly ICardService _cardService;
        private readonly IMapper _mapper;

        public CardsController(ICardService cardService, IMapper mapper)
        {
            _cardService = cardService;
            _mapper = mapper;
        }

        [Route("/cards/{externalId}")]
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> InsertCardAsync(string externalId)
        {
            try
            {
                var cards = await _cardService.InsertUserCardAsync(externalId, Convert.ToInt32(User.Identity.Name));
                return Ok(cards);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("/cards/{externalId}")]
        [Authorize]
        [HttpDelete]
        public async Task<IActionResult> DeleteCardAsync(string externalId)
        {
            try
            {
                var cards = await _cardService.RemoveUserCardAsync(externalId, Convert.ToInt32(User.Identity.Name));
                return Ok(cards);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("/cards")]
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetCardsAsync()
        {
            try
            {
                var cards = await _cardService.GetUserCardsAsync(Convert.ToInt32(User.Identity.Name));
                return Ok(cards);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
