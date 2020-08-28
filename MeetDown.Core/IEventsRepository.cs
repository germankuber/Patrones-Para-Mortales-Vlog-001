using System.Collections.Generic;
using System.Threading.Tasks;

namespace MeetDown.Core
{
    public interface IEventsRepository
    {
        Task<Event> GetByTitle(string title);
        Task<List<Event>> GetAll();
        Task<Event> GetById(int eventId);
        Task Save(Event @event);
    }
}