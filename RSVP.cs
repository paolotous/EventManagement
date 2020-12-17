using System;
using System.Collections.Generic;
using System.Text;

namespace Event_Management
{
    class RSVP
    {
        private Event e;
        private Customer c;
        private EventManager eventMan;
        private CustomerManager custMan;
        private int regID;
        private string date;
        

        public RSVP(EventManager eventMan, CustomerManager custMan, int regID)
        {
            
            this.eventMan = eventMan;
            this.custMan = custMan;
            this.regID = regID;
        }

        public void setRegID(int regID)
        {
            this.regID = regID;
        }

        public int getRegID()
        {
            return regID;
        }


        //registers a customer to a specific event
        public bool registerID(int cid, int eid)
        {  
            if (custMan.customerExist(cid) && eventMan.eventExists(eid))
            {
                e = eventMan.getEvent(eid);         //e will reference the event object returned here
                c = custMan.getCustomer(cid);      //c will reference the customer object

                if (e.getNumAttendees() < e.getMaxAttendees() && e.attendeeExist(cid) == false)
                {

                    e.addAttendee(custMan.getCustomer(cid));
                    Console.WriteLine("You may find below information of your ticket: ");
                    Console.WriteLine(generateTicket(e, c));
                    Console.WriteLine("------------------------");
                    Console.WriteLine("RSVP has been successfully made");
                    Console.WriteLine("Press any key to continue ... ");
                    Console.ReadLine();
                    return true;
                }
            }

            Console.WriteLine("RSVP Failed");
            Console.WriteLine("Press any key to continue ... ");
            Console.ReadLine();
            return false;

        }

        public string generateTicket(Event e, Customer c)
        {
            date = DateTime.Now.ToString(@"MM\/dd\/yyyy h\:mm tt");
            string s = "Ticket Info: \n";
            s += "Date Purchased: " + date;
            s += "\nRSVP ID: " + regID + "\n";
            s += "------------------------";
            s += "\nEvent Info: \n" + e.ToString() + "\n";
            s += "------------------------";
            s += "\nCustomer Info: \n" + c.ToString();

            return s;
        }

        public string viewRSVP()  
        {
            string s = "Date: " + date;
            s += "\nRSVP Number: " + regID;
            s += "\nCustomer Name: " + c.getFirstName() + " " + c.getLastName();
            s += "\nEvent ID: " + e.getEventId();
            return s;
        }

       


    }
}
