using System;
using System.Collections.Generic;
using System.Text;

namespace Event_Management
{
    class Event
    {
       
            private int eventId;
            private string eventName;
            private string venue;
            private Date eventDate;
            private int maxAttendees;
            private int numAttendees;
            private string dateCreated;
            private Customer[] attendeeList;

            public Event(int eventId, string name, string venue, Date eventDate, int maxAttendees)
            {
                this.eventId = eventId;
                this.eventName = name;
                this.venue = venue;
                this.eventDate = eventDate;
                this.maxAttendees = maxAttendees;
                numAttendees = 0;
                attendeeList = new Customer[maxAttendees];
                dateCreated = DateTime.Now.ToString(@"MM\/dd\/yyyy h\:mm tt");
            }

            public int getEventId() { return eventId; }
            public string getEventName() { return eventName; }
            public string getVenue() { return venue; }

            public Date getEventDate() { return eventDate; }

            public int getEventDay() { return eventDate.day; }

            public int getEventMonth() { return eventDate.month; }

            public int getEventYear() { return eventDate.year; }

            public int getMaxAttendees() { return maxAttendees; }
            public int getNumAttendees() { return numAttendees; }

            public bool addAttendee(Customer c)
            {
                if (numAttendees >= maxAttendees) { return false; }
                attendeeList[numAttendees] = c;
                numAttendees++;
                c.setNumBookings(c.getNumBookings() + 1);
                return true;
            }

            private int findAttendee(int custId)
            {
                for (int x = 0; x < maxAttendees; x++)
                {
                    if (attendeeList[x].getId() == custId)
                        return x;
                }
                return -1;
            }

            public bool removeAttendee(int custId)
            {
                int loc = findAttendee(custId);
                if (loc == -1) return false;
                attendeeList[loc] = attendeeList[numAttendees - 1];
                numAttendees--;
                return true;
            }

            public bool attendeeExist(int custId)
        {
            for(int i = 0; i < numAttendees; i++)
            {
                if(attendeeList[i].getId() == custId)
                {
                    return true;
                }
            }

            return false;
        }

            public string getAttendees()
            {
                string s = "\nCustomers registered :";
                for (int x = 0; x < numAttendees; x++)
                {
                    s = s + "\n" + attendeeList[x].getFirstName() + " " + attendeeList[x].getLastName();
                    s += "\nCustomer ID: " + attendeeList[x].getId();
                }
                return s;
            }

            public override string ToString()
            {
                string s = "Event: " + eventId + "\nName: " + eventName;
                s = s + "\nVenue: " + venue;
                s = s + "\nDate:" + eventDate;
                s = s + "\nRegistered Attendees:" + numAttendees;
                s = s + "\nAvailable spaces:" + (maxAttendees - numAttendees);
                s = s + getAttendees();
                return s;
            }

        }

    }

