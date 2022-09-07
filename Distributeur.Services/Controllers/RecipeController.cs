using Distributeur.Domain;
using Distributeur.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Distributeur.Services.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RecipeController : ControllerBase
    {
        private readonly ILogger<RecipeController> _logger;
        private readonly IRecipeDomain _recipeDomain;

        public RecipeController(ILogger<RecipeController> logger, IRecipeDomain recipeDomain)
        {
            _logger = logger;
            _recipeDomain = recipeDomain;
        }
        /// <summary>
        /// Get the price of a beverage
        /// </summary>
        /// <param name="beverageName">Beverage name</param>
        /// <returns>Price in euros</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(double))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        public IActionResult GetPrice(string beverageName)
        {
            try
            {
                return Ok(_recipeDomain.GetPrice(beverageName));

            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
        }
    }
}