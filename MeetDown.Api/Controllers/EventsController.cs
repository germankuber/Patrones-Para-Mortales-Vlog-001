using System.Threading.Tasks;

using MeetDown.Core;

using Microsoft.AspNetCore.Mvc;


namespace MeetDown.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {

        public IEventsRepository _eventsRepository { get; set; }

        //[HttpPost]
        //public async Task<IActionResult> ChangeTitle(int eventId, string newTitle)
        //{
        //    var @event = await _eventsRepository.GetByTitle(newTitle);

        //    if (@event != null)
        //        return BadRequest();

        //    @event = await _eventsRepository.GetById(eventId);

        //    var result = @event.ChangeTitle(newTitle);

        //    if (!result.IsSuccessful())
        //        return BadRequest();

        //    await _eventsRepository.Save(@event);

        //    return Ok();
        //}


        //[HttpPost]
        //public async Task<IActionResult> ChangeTitle(int eventId, string newTitle)
        //{ 2

        //    var @event = await _eventsRepository.GetById(eventId);

        //    var result = await @event.ChangeTitleAsync(newTitle, _eventsRepository);

        //    if (!result.IsSuccessful())
        //        return BadRequest();

        //    await _eventsRepository.Save(@event);

        //    return Ok();
        //}


        [HttpPost]
        public async Task<IActionResult> ChangeTitle(int eventId, string newTitle)
        {
            var events = await _eventsRepository.GetAll();
            
            var @event = await _eventsRepository.GetById(eventId);

            var result = await @event.ChangeTitleAsync(newTitle, _eventsRepository);

            if (!result.IsSuccessful())
                return BadRequest();

            await _eventsRepository.Save(@event);

            return Ok();
        }

    }
}
