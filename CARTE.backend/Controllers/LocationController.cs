using Infrastructure.Users.Commands.SetLocation;
using Microsoft.AspNetCore.Mvc;

namespace CARTE.backend.Controllers
{
    public class LocationController : BaseController
    {
        [HttpPost("{Latitude}./{Longitude}./userId")]
        public async Task<ActionResult> SetLocation(double Latitude, double Longitude, Guid userId)
        {
            var command = new SetLocationCommand 
            { 
                Latitude = Latitude,
                Longitude = Longitude,
                UserId = userId
            };

            await Mediator.Send(command);

            return Ok();
        }
    }
}
