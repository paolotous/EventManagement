using System;

namespace Event_Management
{
    class Program
    {
        static EventCoordinator eCoord;

        public static void deleteCustomer()
        {
            int id;
            Console.Clear();
            Console.WriteLine(eCoord.customerList());
            Console.Write("Please enter a customer id to delete:");
            id = getIntChoice();
            if (eCoord.deleteCustomer(id))
            {
                Console.WriteLine("Customer with id {0} deleted..", id);
            }
            else
            {
                Console.WriteLine("Customer with id {0} was not found..", id);
            }
            Console.WriteLine("\nPress any key to continue return to the main menu.");
            Console.ReadKey();
        }


        public static void viewCustomers()
        {
            Console.Clear();
            Console.WriteLine(eCoord.customerList());
            Console.WriteLine("\nPress any key to continue return to the main menu.");
            Console.ReadKey();
        }

        public static void viewSpecificCustomer()
        {
            int id;
            string cust;
            Console.Clear();
            Console.WriteLine(eCoord.customerList());
            Console.Write("Please enter a customer id to View:");
            id = getIntChoice();
            Console.Clear();
            cust = eCoord.getCustomerInfoById(id);
            Console.WriteLine(cust);
            Console.WriteLine("\nPress any key to continue return to the previous menu.");
            Console.ReadKey();
        }

        public static void addCustomer()
        {
            string fname, lname, phone;

            Console.Clear();
            Console.WriteLine("-----------Add Customer----------");
            Console.Write("Please enter the customer's first name:");
            fname = Console.ReadLine();
            Console.Write("Please enter the customer's last name:");
            lname = Console.ReadLine();
            Console.Write("Please enter the customer's phone:");
            phone = Console.ReadLine();
            if (eCoord.addCustomer(fname, lname, phone))
            {
                Console.WriteLine("Customer successfully added..");
            }
            else
            {
                Console.WriteLine("Customer was not added..");
            }
            Console.WriteLine("\nPress any key to continue return to the main menu.");
            Console.ReadKey();
        }

        public static void registerCustomer()
        {
            int cid = 0;
            int eid = 0;
            bool validEvent = false;
            bool validCustomer = false;
            
            //show the list of customers and events
            Console.Clear();
            Console.WriteLine("-----------List of Customers----------");
            Console.WriteLine(eCoord.customerList());
            Console.WriteLine("-----------List of Events-------------");
            Console.WriteLine(eCoord.eventList());
            Console.WriteLine("-----------RSVP Event-----------------");

            //prompt the user and use both ids to call the register method via the EventCoordinator object
            while (validEvent == false)
            {
                Console.WriteLine("Please enter the Event ID: ");
                if (Int32.TryParse(Console.ReadLine(), out eid))
                {
                    validEvent = true;
                }
            }
            while (validCustomer == false)
            {
                Console.WriteLine("Please enter the Customer ID: ");
                if (Int32.TryParse(Console.ReadLine(), out cid))
                {
                    validCustomer = true;
                }
            }

            if (validCustomer == true && validEvent == true)
            {
                eCoord.register(cid, eid);
            }
        }

        public static void registrations()
        {
            //this will view all processed RSVPs
            Console.Clear();
            Console.WriteLine("-----------List of RVSP----------");
            Console.WriteLine(eCoord.viewRegs());
            Console.WriteLine("Press any key to continue ...");
            Console.ReadLine();
        }

        public static void addEvent()
        {
            string eventName, venue;
            Date eventDate;
            int maxAttendees;
            int day, month, year, hour, minute;

            Console.Clear();
            Console.WriteLine("-----------Add Event----------");
            Console.Write("Please enter the name of the Event:");
            eventName = Console.ReadLine();
            Console.Write("Please enter venue for the event:");
            venue = Console.ReadLine();
            Console.Write("Please enter the Day of the event:");
            day = getIntChoice();
            Console.Write("Please enter the Month of the event (as an integer):");
            month = getIntChoice();
            Console.Write("Please enter the Year of the event:");
            year = getIntChoice();
            Console.Write("Please enter the Hour the event starts in 24 hour format:");
            hour = getIntChoice();
            Console.Write("Please enter the Minute the event starts:");
            minute = getIntChoice();
            eventDate = new Date(day, month, year, hour, minute);
            Console.Write("Please enter the maximum number of attendees:");
            maxAttendees = getIntChoice();
            if (eCoord.addEvent(eventName, venue, eventDate, maxAttendees))
            {
                Console.WriteLine("Event successfully added..");
            }
            else
            {
                Console.WriteLine("The event was not added..");
            }
            Console.WriteLine("\nPress any key to continue return to the main menu.");
            Console.ReadKey();
        }


        public static void viewEvents()
        {
            Console.Clear();
            Console.WriteLine(eCoord.eventList());
            Console.WriteLine("\nPress any key to continue return to the main menu.");
            Console.ReadKey();
        }

        public static void viewSpecificEvent()
        {
            int id;
            string ev;
            Console.Clear();
            Console.WriteLine(eCoord.eventList());
            Console.Write("Please enter an event id to View:");
            id = getIntChoice();
            Console.Clear();
            ev = eCoord.getEventInfoById(id);
            Console.WriteLine(ev);
            Console.WriteLine("\nPress any key to continue return to the previous menu.");
            Console.ReadKey();
        }


        public static string customerMenu()
        {
            string s = "Andrew's Event Management Limited.\n";
            s += "Customer Menu.\n";
            s += "Please select a choice from the menu below:\n";
            s += "1: Add Customer \n";
            s += "2: View Customers \n";
            s += "3: View Customer Details \n";
            s += "4: Delete Customer\n";
            s += "5: Return to the main menu.";
            return s;
        }

        public static string eventMenu()
        {
            string s = "Andrew's Event Management Limited.\n";
            s += "Event Menu.\n";
            s += "Please select a choice from the menu below:\n";
            s += "1: Add Event \n";
            s += "2: View all Events \n";
            s += "3: View Event Details \n";
            s += "4: Return to the main menu.";
            return s;
        }

        public static string registrationMenu()
        {
            string s = "Star Wars Event Management Limited.\n";
            s += "Event Registration Menu.\n";
            s += "Please select a choice from the menu below:\n";
            s += "1: RSVP for event \n";
            s += "2: View RSVPs \n";
            s += "3: Return to the main menu.";
            return s;
        }

        public static string mainMenu()
        {
            string s = "Star Wars Event Management Limited.\n";
            s += "Please select a choice from the menu below:\n";
            s += "1: Customer Options \n";
            s += "2: Event Options \n";
            s += "3: RSVP for Event \n";
            s += "4: Exit";
            return s;
        }


        public static void runCustomerMenu()
        {
            string menu = customerMenu();
            int choice = getValidChoice(5, menu);
            while (choice != 5)
            {
                if (choice == 1) { addCustomer(); }
                if (choice == 2) { viewCustomers(); }
                if (choice == 3) { viewSpecificCustomer(); }
                if (choice == 4) { deleteCustomer(); }
                choice = getValidChoice(5, menu);
            }
        }

        public static void runEventMenu()
        {
            string menu = eventMenu();
            int choice = getValidChoice(4, menu);
            while (choice != 4)
            {
                if (choice == 1) { addEvent(); }
                if (choice == 2) { viewEvents(); }
                if (choice == 3) { viewSpecificEvent(); }

                choice = getValidChoice(4, menu);
            }
        }

        public static void runRegistrationMenu()
        {
            string menu = registrationMenu();
            int choice = getValidChoice(3, menu);
            while (choice != 3)
            {
                if (choice == 1) { registerCustomer(); }
                if (choice == 2) { registrations(); }

                choice = getValidChoice(3, menu);
            }
        }


        public static int getValidChoice(int max, string menu)
        {
            int choice;
            Console.Clear();
            Console.WriteLine(menu);
            while (!int.TryParse(Console.ReadLine(), out choice) || (choice < 1 || choice > max))
            {
                Console.Clear();
                Console.WriteLine(menu);
                Console.WriteLine("Please enter a valid choice:");
            }
            return choice;
        }

        public static int getIntChoice()
        {
            int choice;
            while (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Please enter an integer:");
            }
            return choice;
        }


        public static void runProgram()
        {
            string menu = mainMenu();
            int choice = getValidChoice(4, menu);
            while (choice != 4)
            {
                if (choice == 1) { runCustomerMenu(); }
                if (choice == 2) { runEventMenu(); }
                if (choice == 3) { runRegistrationMenu(); }

                choice = getValidChoice(4, menu);
            }
        }

        static void Main(string[] args)
        {
            eCoord = new EventCoordinator(200, 1000, 101, 5000);
            runProgram();
            Console.WriteLine("Thank you for using Star Wars Event Management Limited System. ");
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }

    }
}
