using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Apis.Calendar.v3.Data;

namespace XmlCreatorForAic
{
    class DateStringBuilder
    {

        //get Events von Google cal and build strings
        public static IList<string> getDateStrings(int countEvents)
        {
            IList<string> eventsAsString = new List<string>();
            IList<Event> events = GoogleCalConnect.getCalendarItems(countEvents);

            foreach (Event calEvent in events)
            {
                string description = calEvent.Summary;
                DateTime date = DateTime.MinValue;
                bool wholeDay = false;
                if (calEvent.Start.Date != null)
                {
                    date = DateTime.Parse(calEvent.Start.Date);
                    wholeDay = true;
                }
                else
                {
                    date = calEvent.Start.DateTime.Value;
                }
                string myString;
                if (wholeDay)
                {
                    myString = String.Format("{0:ddd} {1:dd.MM} {2}", date, date.Date, description);
                }
                else
                {
                    myString = String.Format("{0:ddd} {1:dd.MM} {2} ({3:d2}:{4:d2})", date, date.Date, description, date.TimeOfDay.Hours, date.TimeOfDay.Minutes);
                }
                eventsAsString.Add(myString);
            }
            return eventsAsString;
        }
    }
}
