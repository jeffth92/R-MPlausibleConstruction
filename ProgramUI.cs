using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RandM_1._0.Event;

namespace RandM_1._0
{
    public class ProgramUI
    {
        public enum Item { plumbus, meeseeks, portalgun };
        public List<Item> inventory = new List<Item>(); 

        Dictionary<string, Room> Rooms = new Dictionary<string, Room>
        {
            {"garage", garage },
            {"house", house },
            {"driveway", driveway },
            {"lab", lab },
            {"laboratory", lab }
        };
        public void Run()
        {
            Room currentRoom = garage;

            Console.Clear();
            Console.WriteLine("You accidentally killed Morty.\n" +
                "In oder to construct a passable fcsimile, you must collect " +
                "enough Mortys from other dimensions to assemble from them " +
                "Morty's genetic structure and connectome.");
            Console.ReadKey();
            bool alive = true;
            while (alive)
            {
                Console.Clear();
                Console.WriteLine(currentRoom.Splash);
                string command = Console.ReadLine().ToLower();

                bool foundExit = false;

                if (command.StartsWith("go ") || command.StartsWith("exit "))
                {
                    foreach (string exit in currentRoom.Exits)
                    {
                        if (command.Contains(exit) &&
                            Rooms.ContainsKey(exit))
                        {
                            currentRoom = Rooms[exit];
                            foundExit = true;
                            break;
                        }
                    }
                    if (!foundExit)
                    {
                        Console.WriteLine("Uh... Go where?");
                    }
                    if (command.Contains("garage"))
                    {
                        currentRoom = garage;
                    }
                    else if (command.Contains("drivewway"))
                    {
                        currentRoom = driveway;
                    }
                    else if (command.Contains("house"))
                    {
                        currentRoom = house;
                    }
                    Console.WriteLine("Uh... Go where?");
                }
                else if (command.StartsWith("get ") || command.StartsWith("take ") || command.StartsWith("grab "))
                {
                    bool foundItem = false;
                    foreach (Item item in currentRoom.Items)
                    {
                        if (!foundItem && command.Contains(item.ToString()))
                        {
                            Console.WriteLine($"You found a(n) {item}." +
                                "Press any key to continue...");
                            currentRoom.RemoveItem(item);
                            inventory.Add(item);
                            foundItem = true;
                            Console.ReadKey();
                            break;
                        }
                    }
                    if (!foundItem)
                    {
                        Console.WriteLine("I don't know what you're talking about.");
                    }
                }
                else if (command.StartsWith("use ") || command.StartsWith("activate "))
                {
                    string eventMessage = "I doubt you know how.";
                    foreach (Event roomEvent in currentRoom.Events)
                    {
                        if (!command.Contains(roomEvent.TriggerPhrase) || roomEvent.Type != EventType.Use)
                        {
                            continue;
                        }
                        if (roomEvent.EventResult.Type == Result.ResultType.NewExit)
                        {
                            currentRoom.Exits.Add(roomEvent.EventResult.ResultExit); //all messed up line
                            eventMessage = roomEvent.EventResult.ResultMessage;
                        }
                        else if (roomEvent.EventResult.Type == Result.ResultType.GetItem)
                        {
                            inventory.Add(roomEvent.EventResult.ResultItem);
                            eventMessage = roomEvent.EventResult.ResultMessage;
                        }
                        else if (roomEvent.EventResult.Type == Result.ResultType.MessageOnly)
                        {
                            eventMessage = roomEvent.EventResult.ResultMessage;
                        }
                    }
                    Console.WriteLine(eventMessage);
                }
                else
                {
                    Console.WriteLine("*BUUUUURP* What?");
                }
            }
        }

        public static Room garage = new Room(
            "\n\n\n\n\nYou're in the garage with all your junk and crap. \n\n" +
                "Obvious exits are the DRIVEWAY and HOUSE\n",
            new List<string> { "driveway", "house" },
            new List<Item> { Item.plumbus },
            new List<Event> {
                new Event(
                    "control panel",
                    EventType.Use,
                    new Result("laboritory", "You've opened the hatch to your LABORITORY.")
                    )
            }
        );
        public static Room driveway = new Room(
            "\n\n\n\n\nYou're in the driveway. The car is gone but " +
            "the oil stain in the gararge is still there.\n\n" +
            "Obvious exits are the GARAGE and the YARD\n",
            new List<string> { "garage" },
            new List<Item> { },
            new List<Event> { }
        );
        public static Room house = new Room(
            "\n\n\n\n\nYou're in the house now. It's drab and smells like " +
            "lemon pine-sol with a hint of stale fart.\n\n" +
            "Obvious exits are the Garage and the Kitchen\n",
            new List<string> { "garage" },
            new List<Item> { },
            new List<Event> { }
        );
        public static Room lab = new Room(
            "n\n\n\n\nYou've entered your secret lab under the garage." +
            " It's way nicer than the rest of the house.\n\n" +
            "Obvious exits are GARAGE\n",
            new List<string> { "garage" },
            new List<Item> { },
            new List<Event> { }
        );

    }
}
