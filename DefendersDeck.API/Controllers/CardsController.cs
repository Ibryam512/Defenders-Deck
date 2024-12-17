﻿using DefendersDeck.Business.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DefendersDeck.API.Controllers
{
    [Authorize]
    public class CardsController(ICardService cardService) : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetCards()
        {
            var response = await cardService.GetCardsAsync();

            return response.Success
                    ? Ok(response) 
                    : HandleFailure(response);
        }

        [HttpGet("market")]
        public async Task<IActionResult> GetCardsForMarket()
        {
            int userId = RetrieveUserId();
            
            if (userId == 0)
            {
                return NotFound();
            }

            var response = await cardService.GetCardsForMarketAsync(userId);

            return response.Success
                    ? Ok(response)
                    : HandleFailure(response);
        }

        [HttpGet("deck")]
        public async Task<IActionResult> GetDeck()
        {
            int userId = RetrieveUserId();

            if (userId == 0)
            {
                return NotFound();
            }

            var response = await cardService.GetDeckAsync(userId);

            return response.Success
                    ? Ok(response)
                    : HandleFailure(response);
        }
    }
}