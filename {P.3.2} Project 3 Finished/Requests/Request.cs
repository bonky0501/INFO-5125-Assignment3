using System;

/* Authors: Michael Tracy, Isaac Lajoie, Bon Ky
 * Course: INFO 5125
 * Due Date: March 28th, 2024
 * Assignment: #3
 */

namespace Assi3
{
    class Request : Command
    {
        
        public Request(string route, int payload) {
            Route = route;
            Payload = payload;
        }
        public Route r { get; set; }
        public string Route;
        public int Payload;

        //allows the client to set the Route r, which allows ExecuteRequest to function without having any parameters.
        //(was shown in class that it doesn't want any)
        public void Set_Route(Route r)
        {
            this.r = r;
        }
        //executes the CheckOtherRoutes function on the the Route r.
        public int ExecuteRequest()
        {
            return r.CheckOtherRoutes(this);
        }

    
    }
}
