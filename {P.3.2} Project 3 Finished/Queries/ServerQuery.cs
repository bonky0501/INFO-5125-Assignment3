using System;

/* Authors: Michael Tracy, Isaac Lajoie, Bon Ky
 * Course: INFO 5125
 * Due Date: March 28th, 2024
 * Assignment: #3
 */

namespace Assi3
{
    class ServerQuery : Query
    {
        //check to see if the server is actually available 
        public bool isServerAvailable(Server server)
        {
            return server.isAvailable();
        }
    }
}
