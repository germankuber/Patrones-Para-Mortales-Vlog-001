using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace MeetDown.Core
{
    public class Event : Entity
    {
        public ScheduleEvent Schedule { get; set; }
        public string Title { get; private set; }

        public async Task<Result> ChangeTitleAsync(string title,
            IEventsRepository eventsRepository)
        {
            var @event = await eventsRepository.GetByTitle(title);

            if (@event != null)
                return Result.Failure();

            if (!Schedule.EnableToModified())
                return Result.Failure();

            Title = title;

            return Result.Success();
        }


        //public Result ChangeTitle(string title, List<Event> events)
        //{
        //    if (events.Any(x => x.Title == title))
        //        return Result.Failure();

        //    if (!Schedule.EnableToModified())
        //        return Result.Failure();

        //    Title = title;

        //    return Result.Success();
        //}

    }
}