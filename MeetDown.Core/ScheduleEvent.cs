using System;

namespace MeetDown.Core
{
    public class ScheduleEvent
    {
        public DateTime Time { get; set; }

        public bool EnableToModified()
        {
            if (DateTime.Now < Time)
                return false;
            return true;
        }
    }
}