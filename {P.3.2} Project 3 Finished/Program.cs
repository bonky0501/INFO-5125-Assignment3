using System;
using System.Collections.Generic;

/* Authors: Michael Tracy, Isaac Lajoie, Bon Ky
 * Course: INFO 5125
 * Due Date: March 28th, 2024
 * Assignment: #3
 */


namespace Assi3
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Server> Servers = new List<Server>();
            Queue<Request> PendingRequests = new Queue<Request>();

            Console.WriteLine("Please enter a command.");
            string command = "";

            while(command != "quit") {
                string[] commandArgs = command.Split(":");
                Console.WriteLine();

                switch(commandArgs[0]) {
                    case "help":
                        Console.WriteLine("help\t\t\tDisplay this menu");
                        Console.WriteLine("createserver\t\tCreate a new server.");
                        Console.WriteLine("deleteserver:[id]\tDelete server #ID.");
                        Console.WriteLine("listservers\t\tList all servers.");
                        Console.WriteLine("new:[path]:[payload]\tCreate a new pending request.");
                        Console.WriteLine("dispatch\t\tSend a pending request to a server.");
                        Console.WriteLine("server:[id]\t\tHave server #ID execute its pending request and print the result.");
                        Console.WriteLine("quit\t\t\tQuit the application");
                        break;
                    //Very basic creation of the server and then adding it to the server list
                    case "createserver":
                        Server server = new Server();
                        Servers.Add(server);
                        Console.WriteLine($"Created server {Servers.Count - 1}");
                        break;
                    //delete the specified server in a try catch block to make sure the program doesn't crash and to also catch any errors with
                    //Int32.Parse
                    case "deleteserver":
                        try
                        {
                            Servers.RemoveAt(Int32.Parse( commandArgs[1]));
                            Console.WriteLine($"Deleted server {commandArgs[1]}");
                        }
                        catch (Exception) {
                            Console.WriteLine("Invalid ID specified.");
                        }
                        break;
                    //Lists all servers to the client
                    case "listservers":
                        for (int i =0; i < Servers.Count; i++)
                        {
                            Console.WriteLine($"{i}: server");
                        }
                        break;
                    //checks to see if the any args are nonexistant, has a try catch to mainly catch errors with Int32.Parse and 
                    //an if statement to return an error if the payload or path is wrong
                    case "new":
                        try
                        {
                            if(commandArgs[1] != "" && commandArgs[2] != "")
                            {
                                Request request = new Request(commandArgs[1], Int32.Parse(commandArgs[2]));

                                PendingRequests.Enqueue(request);
                                Console.WriteLine($"Created request with data {commandArgs[2]} going to {commandArgs[1]}.");
                            }
                            else { Console.WriteLine("Invalid payload or path specified."); }
                            
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Error, please enter a proper integer.");
                        }
                       

                        break;
                        //loops through and finds a server to take the dispatch, if it can't find a server it will give back a message to the client
                        
                    case "dispatch":
                        try
                        {
                            if(PendingRequests.Count == 0)
                            {
                                Console.WriteLine("No pending requests.");
                            }
                            else
                            {
                                bool serverFound = false;
                                int index = 0;
                                for (int i = 0; i < Servers.Count; i++) 
                                {
                                    if (Servers[i]._available && serverFound == false) 
                                    {
                                        Servers[i].IncomingRequest(PendingRequests.Dequeue());
                                        serverFound = true;
                                        index = i;
                                    }
                                }
                                if (serverFound)
                                {
                                    Console.WriteLine($"Request sent to {index} server");
                                }
                                else
                                {
                                    Console.WriteLine("No servers available (521).");
                                }

                            }
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Error with dispatching");
                        }

                        break;
                        //another try catch block to make sure Int32.Parse works, runs the specified server from the server list.
                    case "server":
                        try
                        {

                            Servers[Int32.Parse(commandArgs[1])].Run();

                        }
                        catch (Exception ) { Console.WriteLine("Error, please enter a proper integer or a real server number."); }
                        break;
                    default:
                        if(command != "") {
                            Console.WriteLine("Invalid command.");
                        }
                        break;
                }

                Console.WriteLine();
                command = Console.ReadLine();
            }
        }
    }
}
