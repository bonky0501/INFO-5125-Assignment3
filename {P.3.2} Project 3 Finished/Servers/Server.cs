using System;

/* Authors: Michael Tracy, Isaac Lajoie, Bon Ky
 * Course: INFO 5125
 * Due Date: March 28th, 2024
 * Assignment: #3
 */

namespace Assi3
{
    class Server : AbstractServer
    {

        //create some variablesto be used below, added in an available bool to check easily
        public bool _available = true;
        public Request openRequest;
        public Route _route;
        //create the chain of command that will be used, put it into the constructor so it can be properly built every 
        //time a server is amde. return nothing at the end which will return null and default to 404
        public Server()
        {
            _route = new AddRoute("/add", new MultiplyRoute("/mul", new Multiply4Route("/mul/4")));
        }

        //give the server the incoming request, also set availble to false so it can't recieve another one
        public void IncomingRequest(Request request)
        {
            this.openRequest = request;
            _available = false;
        }
        public bool isAvailable()
        {
            return _available;
        }
        //runs the command, sets the route to check for the proper route
        public void Run()
        {
            //made the condidtion openRequest here as it is more definite that it wont return null in some edge cases
            if(openRequest != null)
            {
                openRequest.Set_Route(_route);
                int new_Result = openRequest.ExecuteRequest();
                Console.WriteLine($"Path: {openRequest.Route}");
                Console.WriteLine($"Input: {openRequest.Payload}");
                Console.WriteLine($"Result: {new_Result}");
                //make availble and set open request to be null since it has been completed
                _available = true;
                openRequest = null;
            }
            else
            {
                //tell the client theres no work to be done
                Console.WriteLine("No work to do");
            }
        }

    }
}
